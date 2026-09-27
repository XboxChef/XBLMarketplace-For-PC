using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    /// <summary>
    /// Checks the download links of the listed content a few at a time.
    /// Call it from the UI thread, results and progress are reported there.
    /// </summary>
    public sealed class BatchUrlChecker
    {
        public const int DefaultParallelism = 6;
        private const int Attempts = 3;

        public UiBindingList<MarketPlaceContent> _content;

        /// <summary>
        /// Checks running at once. 0 only checks when asked (Re-Check List, Generate URL, Direct Download).
        /// </summary>
        public int Parallelism = DefaultParallelism;

        private CheckRun _run;
        private readonly Dictionary<MarketPlaceContent, Task<bool>> _inFlight = new Dictionary<MarketPlaceContent, Task<bool>>();

        public BatchUrlChecker(UiBindingList<MarketPlaceContent> content)
        {
            _content = content;
        }

        public event EventHandler<CheckProgressEventArgs> ProgressChanged;

        /// <summary>
        /// Fires after an item's check finishes, whether it succeeded or not.
        /// </summary>
        public event EventHandler<MarketPlaceContent> ItemChecked;

        public void Abort()
        {
            if (_run == null) return;
            _run.Cancel.Cancel();
            _run = null;
        }

        public void StartUrlCheck(bool recheck)
        {
            Abort();
            var run = new CheckRun
            {
                Force = recheck,
                Queue = _content.Where(c => recheck || !c.DownloadChecked).ToList()
            };
            run.Total = run.Queue.Count;
            _run = run;

            //Re-Check List is an explicit request, so it runs even with automatic checking off
            int workers = recheck ? Math.Max(1, Parallelism) : Parallelism;
            run.AutoCheckOff = workers == 0;
            OnProgress(run);
            for (int i = 0; i < Math.Min(workers, run.Queue.Count); i++) Work(run);
        }

        /// <summary>
        /// Moves a queued item out of line and checks it now, used for the selected item.
        /// </summary>
        public async void Prioritize(MarketPlaceContent item)
        {
            CheckRun run = _run;
            if (run == null || run.AutoCheckOff || !run.Queue.Remove(item)) return;
            await CheckOne(run, item);
        }

        /// <summary>
        /// Checks one item unless it already has a result. Returns false if Xbox Live couldn't be reached.
        /// </summary>
        public Task<bool> CheckAsync(MarketPlaceContent item, bool force = false)
        {
            Task<bool> running;
            if (_inFlight.TryGetValue(item, out running)) return running;
            if (!force && item.DownloadChecked) return Task.FromResult(true);

            running = RunCheck(item, force);
            if (!running.IsCompleted) _inFlight[item] = running;
            return running;
        }

        private async void Work(CheckRun run)
        {
            while (!run.Cancel.IsCancellationRequested && run.Queue.Count > 0)
            {
                MarketPlaceContent item = run.Queue[0];
                run.Queue.RemoveAt(0);
                await CheckOne(run, item);
            }
        }

        private async Task CheckOne(CheckRun run, MarketPlaceContent item)
        {
            bool ok = await CheckAsync(item, run.Force);
            if (run.Cancel.IsCancellationRequested) return;
            run.Done++;
            if (!ok) run.Failed++;
            OnProgress(run);
        }

        private async Task<bool> RunCheck(MarketPlaceContent item, bool force)
        {
            item.CheckStatus = "Checking…";
            Refresh(item);
            try
            {
                for (int attempt = 1; ; attempt++)
                {
                    try
                    {
                        await Task.Run(() => item.CheckDownloadUrl(false, force));
                        item.CheckStatus = null;
                        return true;
                    }
                    catch (Exception e) when (attempt < Attempts)
                    {
                        Console.WriteLine(e.ToString());
                        //Back off in case Xbox Live is struggling
                        await Task.Delay(500 * attempt);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        //Nothing is cached for a failed check, so it is retried next time the page is shown
                        item.CheckStatus = item.DownloadChecked ? null : "Error";
                        return false;
                    }
                }
            }
            finally
            {
                _inFlight.Remove(item);
                Refresh(item);
                ItemChecked?.Invoke(this, item);
            }
        }

        private void Refresh(MarketPlaceContent item)
        {
            int index = _content.IndexOf(item);
            if (index >= 0) _content.ResetItem(index);
        }

        private void OnProgress(CheckRun run)
        {
            ProgressChanged?.Invoke(this, new CheckProgressEventArgs(run.Done, run.Total, run.Failed, run.AutoCheckOff));
        }

        private class CheckRun
        {
            public readonly CancellationTokenSource Cancel = new CancellationTokenSource();
            public List<MarketPlaceContent> Queue;
            public bool Force;
            public bool AutoCheckOff;
            public int Total;
            public int Done;
            public int Failed;
        }
    }

    public class CheckProgressEventArgs : EventArgs
    {
        public CheckProgressEventArgs(int done, int total, int failed, bool autoCheckOff)
        {
            Done = done;
            Total = total;
            Failed = failed;
            AutoCheckOff = autoCheckOff;
        }

        public int Done { get; }
        public int Total { get; }
        public int Failed { get; }
        public bool AutoCheckOff { get; }
        public int Percent => Total == 0 ? 100 : Done * 100 / Total;
    }
}
