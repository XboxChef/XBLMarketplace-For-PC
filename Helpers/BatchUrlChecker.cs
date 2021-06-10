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
    private SynchronizationContext _uithread;
    private BackgroundWorker bgw = new BackgroundWorker()
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
      this._content = content;
      this._uithread = uiThread ?? SynchronizationContext.Current;
      this.bgw.DoWork += new DoWorkEventHandler(this.bgw_DoWork);
      this.bgw.ProgressChanged += new ProgressChangedEventHandler(this.bgw_ProgressChanged);
      this.bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
    }

    public void Abort() => this.bgw.CancelAsync();

    public void StartUrlCheck(bool recheck) => this.bgw.RunWorkerAsync((object) recheck);

    public event DoWorkEventHandler DoWorkStart;

    public event DoWorkEventHandler DoWorkEnd;

    public event ProgressChangedEventHandler ProgressChangedStart;

    public event ProgressChangedEventHandler ProgressChangedEnd;

    public event RunWorkerCompletedEventHandler CompletedStart;

    public event RunWorkerCompletedEventHandler CompletedEnd;

    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      DoWorkEventHandler doWorkStart = this.DoWorkStart;
      if (doWorkStart != null)
        doWorkStart((object) this, e);
      this.StartBatchUrlCheck(this._content, this._uithread, e, (BackgroundWorker) sender);
      DoWorkEventHandler doWorkEnd = this.DoWorkEnd;
      if (doWorkEnd == null)
        return;
      doWorkEnd((object) this, e);
    }

    private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      ProgressChangedEventHandler progressChangedStart = this.ProgressChangedStart;
      if (progressChangedStart != null)
        progressChangedStart((object) this, e);
      ProgressChangedEventHandler progressChangedEnd = this.ProgressChangedEnd;
      if (progressChangedEnd == null)
        return;
      progressChangedEnd((object) this, e);
    }

    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      RunWorkerCompletedEventHandler completedStart = this.CompletedStart;
      if (completedStart != null)
        completedStart((object) this, e);
      if (this.bgw.CancellationPending)
        this.bgw.ReportProgress(0);
      RunWorkerCompletedEventHandler completedEnd = this.CompletedEnd;
      if (completedEnd == null)
        return;
      completedEnd((object) this, e);
    }

    private void StartBatchUrlCheck(
      ThreadedBindingList<MarketPlaceContent> boundList,
      SynchronizationContext threadToInvoke,
      DoWorkEventArgs e,
      BackgroundWorker worker)
    {
      int percentProgress1 = 100;
      this.bgw.ReportProgress(0);
      if (this.NetworkDelay == 0)
      {
        this.bgw.ReportProgress(percentProgress1);
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
            Decimal num2 = (Decimal) (list.IndexOf(marketPlaceContent1) + 1);
            int num3 = num1 * millisecondsTimeout * this.NetworkDelay;
            int count = list.Count;
            int percentProgress2 = (int) Math.Ceiling(num2 / (Decimal) count * (Decimal) percentProgress1);
            if (worker.CancellationPending && !(bool) e.Argument)
              break;
            if (!marketPlaceContent1.DownloadChecked || (bool) e.Argument)
            {
              marketPlaceContent1.CheckDownloadUrl(worker.CancellationPending, (bool) e.Argument);
              MarketPlaceContent marketPlaceContent2 = boundList.ElementAtOrDefault<MarketPlaceContent>(list.IndexOf(marketPlaceContent1));
              if (marketPlaceContent2 != null && marketPlaceContent2.TitleId == marketPlaceContent1.TitleId)
                boundList[list.IndexOf(marketPlaceContent1)] = marketPlaceContent1;
              this.bgw.ReportProgress(percentProgress2);
              if (marketPlaceContent1.DownloadChecked || (bool) e.Argument)
              {
                if (list.IndexOf(marketPlaceContent1) < list.Count)
                {
                  for (int index = 0; index < this.NetworkDelay * num1; ++index)
                  {
                    this.bgw.ReportProgress((int) Math.Ceiling(((Decimal) (millisecondsTimeout * index) + num2 * (Decimal) num3) / (Decimal) (num3 * (count + 1)) * (Decimal) percentProgress1));
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
                  int num4 = (int) Math.Ceiling((num2 + (Decimal) (1 / count)) * (Decimal) percentProgress1);
                }
              }
            }
            else
              this.bgw.ReportProgress(percentProgress2);
          }
        }
        catch (InvalidOperationException ex)
        {
          boundList.ResetBindings();
          Console.WriteLine(e.ToString());
          throw;
        }
      }
    }

    private void Dispose(bool disposing)
    {
      if (this.disposedValue)
        return;
      if (disposing)
      {
        this.bgw.DoWork -= new DoWorkEventHandler(this.bgw_DoWork);
        this.bgw.ProgressChanged -= new ProgressChangedEventHandler(this.bgw_ProgressChanged);
        this.bgw.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
        this.bgw.Dispose();
      }
      this.disposedValue = true;
    }

    public void Dispose() => this.Dispose(true);
  }
}
