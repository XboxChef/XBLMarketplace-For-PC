// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Helpers.BatchUrlChecker
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    public sealed class BatchUrlChecker : IDisposable
    {
        public ThreadedBindingList<MarketPlaceContent> _content;
        private readonly SynchronizationContext _uithread;
        private readonly BackgroundWorker bgw = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        public int NetworkDelay;
        private bool disposedValue;

        public BatchUrlChecker(
          ThreadedBindingList<MarketPlaceContent> content,
          SynchronizationContext uiThread)
        {
            _content = content;
            _uithread = uiThread ?? SynchronizationContext.Current;
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
        }

        public void Abort() => bgw.CancelAsync();

        public void StartUrlCheck(bool recheck) => bgw.RunWorkerAsync(recheck);

        public event DoWorkEventHandler DoWorkStart;

        public event DoWorkEventHandler DoWorkEnd;

        public event ProgressChangedEventHandler ProgressChangedStart;

        public event ProgressChangedEventHandler ProgressChangedEnd;

        public event RunWorkerCompletedEventHandler CompletedStart;

        public event RunWorkerCompletedEventHandler CompletedEnd;

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWorkEventHandler doWorkStart = DoWorkStart;
            if (doWorkStart != null)
                doWorkStart(this, e);
            StartBatchUrlCheck(_content, _uithread, e, (BackgroundWorker)sender);
            DoWorkEventHandler doWorkEnd = DoWorkEnd;
            if (doWorkEnd == null)
                return;
            doWorkEnd(this, e);
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChangedEventHandler progressChangedStart = ProgressChangedStart;
            if (progressChangedStart != null)
                progressChangedStart(this, e);
            ProgressChangedEventHandler progressChangedEnd = ProgressChangedEnd;
            if (progressChangedEnd == null)
                return;
            progressChangedEnd(this, e);
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompletedEventHandler completedStart = CompletedStart;
            if (completedStart != null)
                completedStart(this, e);
            if (bgw.CancellationPending)
                bgw.ReportProgress(0);
            RunWorkerCompletedEventHandler completedEnd = CompletedEnd;
            if (completedEnd == null)
                return;
            completedEnd(this, e);
        }

        private void StartBatchUrlCheck(
          ThreadedBindingList<MarketPlaceContent> boundList,
          SynchronizationContext threadToInvoke,
          DoWorkEventArgs e,
          BackgroundWorker worker)
        {
            int percentProgress1 = 100;
            bgw.ReportProgress(0);
            if (NetworkDelay == 0)
            {
                bgw.ReportProgress(percentProgress1);
            }
            else
            {
                try
                {
                    List<MarketPlaceContent> list = boundList.ToList<MarketPlaceContent>();
                    foreach (MarketPlaceContent marketPlaceContent1 in list)
                    {
                        int num1 = 40;
                        int millisecondsTimeout = 1000 / num1;
                        Decimal num2 = list.IndexOf(marketPlaceContent1) + 1;
                        int num3 = num1 * millisecondsTimeout * NetworkDelay;
                        int count = list.Count;
                        int percentProgress2 = (int)Math.Ceiling(num2 / count * percentProgress1);
                        if (worker.CancellationPending && !(bool)e.Argument)
                            break;
                        if (!marketPlaceContent1.DownloadChecked || (bool)e.Argument)
                        {
                            marketPlaceContent1.CheckDownloadUrl(worker.CancellationPending, (bool)e.Argument);
                            MarketPlaceContent marketPlaceContent2 = boundList.ElementAtOrDefault<MarketPlaceContent>(list.IndexOf(marketPlaceContent1));
                            if (marketPlaceContent2 != null && marketPlaceContent2.TitleId == marketPlaceContent1.TitleId)
                                boundList[list.IndexOf(marketPlaceContent1)] = marketPlaceContent1;
                            bgw.ReportProgress(percentProgress2);
                            if (marketPlaceContent1.DownloadChecked || (bool)e.Argument)
                            {
                                if (list.IndexOf(marketPlaceContent1) < list.Count)
                                {
                                    for (int index = 0; index < NetworkDelay * num1; ++index)
                                    {
                                        bgw.ReportProgress((int)Math.Ceiling((millisecondsTimeout * index + num2 * num3) / (num3 * (count + 1)) * percentProgress1));
                                        if (!worker.CancellationPending)
                                            Thread.Sleep(millisecondsTimeout);
                                        else
                                            break;
                                    }
                                    if (worker.CancellationPending)
                                        break;
                                }
                                else
                                {
                                    int num4 = (int)Math.Ceiling((num2 + 1 / count) * percentProgress1);
                                }
                            }
                        }
                        else
                            bgw.ReportProgress(percentProgress2);
                    }
                }
                catch (InvalidOperationException)
                {
                    boundList.ResetBindings();
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposedValue)
                return;
            if (disposing)
            {
                bgw.DoWork -= new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged -= new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.Dispose();
            }
            disposedValue = true;
        }

        public void Dispose() => Dispose(true);
    }
}
