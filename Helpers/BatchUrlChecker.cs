using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using JasonNS.Components;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    public sealed class BatchUrlChecker : IDisposable
    {
        public ThreadedBindingList<MarketPlaceContent> _content;
        private SynchronizationContext _uithread;
        private BackgroundWorker bgw = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
        public int NetworkDelay;

        public BatchUrlChecker(ThreadedBindingList<MarketPlaceContent> content, SynchronizationContext uiThread)
        {
            _content = content;
            _uithread = uiThread ?? SynchronizationContext.Current;
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
        }

        public void Abort() => bgw.CancelAsync();
        public void StartUrlCheck(bool recheck) => bgw.RunWorkerAsync(recheck);

        /// <summary>
        /// Event fires when StartUrlCheck() is called, before BatchHelper has processed
        /// </summary>
        public event DoWorkEventHandler DoWorkStart;

        /// <summary>
        /// Event fires when StartUrlCheck() is called, after BatchHelper has processed
        /// </summary>
        public event DoWorkEventHandler DoWorkEnd;

        /// <summary>
        /// Event fires when progress has changed, before BatchHelper has processed
        /// </summary>
        public event ProgressChangedEventHandler ProgressChangedStart;

        /// <summary>
        /// Event fires when progress has changed, after BatchHelper has processed
        /// </summary>
        public event ProgressChangedEventHandler ProgressChangedEnd;

        /// <summary>
        /// Event fires when internal worker is finished, before BatchHelper has processed
        /// </summary>
        public event RunWorkerCompletedEventHandler CompletedStart;

        /// <summary>
        /// Event fires when internal worker is finished, after BatchHelper has processed
        /// </summary>
        public event RunWorkerCompletedEventHandler CompletedEnd;

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWorkStart?.Invoke(this,e);
            StartBatchUrlCheck(_content, _uithread, e, (BackgroundWorker) sender);
            DoWorkEnd?.Invoke(this, e);
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChangedStart?.Invoke(this, e);
            //nothing to do here
            ProgressChangedEnd?.Invoke(this, e);
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompletedStart?.Invoke(this, e);
            if(bgw.CancellationPending) bgw.ReportProgress(0);
            //Probably Something to do here
            CompletedEnd?.Invoke(this, e);
        }

        private void StartBatchUrlCheck(ThreadedBindingList<MarketPlaceContent> boundList, SynchronizationContext threadToInvoke,DoWorkEventArgs e,BackgroundWorker worker)
        {
            int progressbarMax = 100;
            bgw.ReportProgress(0);
            if (NetworkDelay == 0)
            {
                bgw.ReportProgress(progressbarMax);
                return;
            }
            try
            {
                List<MarketPlaceContent> workingContent = boundList.ToList();

                foreach (MarketPlaceContent oneContent in workingContent)
                {//e.argument is ForceRecheck true/false
                    int DelayModifier = 40;//todo Math Over here, Fill progress bar with correct value
                    int Delay = 1000 / DelayModifier;
                    decimal InnerCount;
                    decimal OuterCount = workingContent.IndexOf(oneContent) + 1;
                    int InnerTotal= DelayModifier * Delay * NetworkDelay;
                    int OuterTotal = workingContent.Count;
                    int ProgressPercent = (int)Math.Ceiling(OuterCount / OuterTotal * progressbarMax);
                    






                    if (worker.CancellationPending && !(bool) e.Argument) break;
                    if (!oneContent.DownloadChecked || (bool) e.Argument)
                    {
                        oneContent.CheckDownloadUrl(worker.CancellationPending, (bool) e.Argument);
                    }
                    else
                    {
                        bgw.ReportProgress(ProgressPercent);
                        continue;
                    }
                    var elementAtOrDefault = boundList.ElementAtOrDefault(workingContent.IndexOf(oneContent));
                    if (elementAtOrDefault != null && elementAtOrDefault.TitleId == oneContent.TitleId)
                    {
                        //boundList.RaiseListChangedEvents = false;
                        boundList[workingContent.IndexOf(oneContent)] = oneContent;
                        //boundList.RaiseListChangedEvents = true;
                        //threadToInvoke.Post(delegate { boundList.ResetItem(boundList.IndexOf(oneContent)); }, null);

                    }
                    bgw.ReportProgress(ProgressPercent);
                    //networkdelay * 10 * sleep = TotalDelay
                    if (oneContent.DownloadChecked || (bool)e.Argument)
                    {
                        if (!(workingContent.IndexOf(oneContent) >= workingContent.Count)) //Skip the Delay
                        {
                            //NetworkDelay is Delay as Int Value in Seconds
                            for (int i = 0; i < NetworkDelay*DelayModifier; i++)
                            {
                                InnerCount = Delay*i;

                                ProgressPercent = (int) Math.Ceiling((InnerCount + OuterCount*InnerTotal)/(InnerTotal*(OuterTotal + 1))*progressbarMax);


                                bgw.ReportProgress(ProgressPercent);
                                if (worker.CancellationPending) break;
                                Thread.Sleep(Delay);
                            }
                            if (worker.CancellationPending) break;
                        }
                        else ProgressPercent = (int)Math.Ceiling((OuterCount+1 / OuterTotal) * progressbarMax);
                    }
                }
                    
            }
            catch (InvalidOperationException ex)
            {
                boundList.ResetBindings();
                //Do Nothing Here, This Exception Is Intentional
                //And is Caused by allcontent being changed from user switching the page they are viewing
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    bgw.DoWork -= bgw_DoWork;
                    bgw.ProgressChanged -= bgw_ProgressChanged;
                    bgw.RunWorkerCompleted -= bgw_RunWorkerCompleted;
                    bgw.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~batchworker() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
/*    public class BatchHelper
    {
        public int NetworkDelay;
        public void Abort() => _cts.Cancel();
        public bool WorkDone { get; private set; } = true;
        private CancellationTokenSource _cts= new CancellationTokenSource();
        public bool Recheck;
        public ThreadedBindingList<MarketPlaceContent> Content;
        private SynchronizationContext _uithread;

        public BatchHelper(ThreadedBindingList<MarketPlaceContent> content, SynchronizationContext uiThread)
        {
            Content = content;
            _uithread = uiThread ?? SynchronizationContext.Current;
        }
        public async void StartBatchUrlCheck()
        {
            if (!_cts.IsCancellationRequested) _cts.Cancel();
            _cts = new CancellationTokenSource();
            WorkDone = false;
            await Task.Run(async () =>
            {
                WorkDone = await StartBatchUrlCheck(Content, _uithread);
            });
            
        }
        private async Task<bool> StartBatchUrlCheck(ThreadedBindingList<MarketPlaceContent> boundList, SynchronizationContext threadToInvoke)
        {
            if (NetworkDelay == 0) return true;
            try
            {
                await Task.Run(async () =>
                {
                    List<MarketPlaceContent> workingContent = boundList.ToList();
                    foreach (MarketPlaceContent oneContent in workingContent)
                    {
                        if (_cts.IsCancellationRequested) break;
                        if (oneContent.DownloadChecked && !Recheck) continue;
                        await StartUrlCheck(oneContent, workingContent, boundList, threadToInvoke);
                    }
                });
            }
            catch (InvalidOperationException e)
            {
                boundList.ResetBindings();
                //Do Nothing Here, This Exception Is Intentional
                //And is Caused by allcontent being changed from user switching the page they are viewing
                Console.WriteLine(e.ToString());
            }
            return true;
        }
        private async Task StartUrlCheck(MarketPlaceContent oneContent,List<MarketPlaceContent> workingList, ThreadedBindingList<MarketPlaceContent> boundList, SynchronizationContext threadToInvoke)
        {    }
        public void XmlDocLoaded_Subscribe(Webhelper caller)
        {
            caller.XmlDocLoaded += XmlDocChanged;
        }
        private void XmlDocChanged(object sender, EventArgs a)
        {
            //cts.Cancel();
            Recheck = false;
        }


    }
    */
}