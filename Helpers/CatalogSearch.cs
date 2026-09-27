using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    /// <summary>
    /// Searches a category by title. The catalogue has no text search (only a first letter filter), so this builds
    /// an index of every title from the lighter DetailView 2 pages, matches locally, then fetches full details for the
    /// matches by id. Index pages go through the page cache like any other page.
    /// </summary>
    public class CatalogSearch
    {
        public const int MaxResults = 200;
        private const int IndexPageSize = 300;   //largest page the catalogue serves
        //Detail 1 is smaller but leaves many themes and gamer pictures untitled, detail 2 adds titles and the game's title
        private const string IndexDetailView = "2";
        private const int DetailBatchSize = 20;  //ids per request, the server rejects query strings much past 2 KB
        private const int MaxParallel = 12;   //deep catalogue pages take seconds each, Xbox Live handled 16 at once fine

        private readonly Dictionary<string, List<TitleEntry>> _indexes = new Dictionary<string, List<TitleEntry>>();

        /// <summary>
        /// Call from the UI thread. Progress messages are reported there.
        /// </summary>
        public async Task<SearchResult> SearchAsync(Webhelper helper, string query, IProgress<string> progress)
        {
            string[] words = Normalize(query).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0) return new SearchResult(new List<XElement>(), 0, true);

            string key = helper.MediaTypes.Id + "|" + helper.Language.Code + "|" + helper.Locales.LegalId;
            List<TitleEntry> index;
            bool complete = true;
            if (!_indexes.TryGetValue(key, out index))
            {
                var built = await BuildIndexAsync(helper, progress);
                index = built.Item1;
                complete = built.Item2;
                //An index with missing pages is used for this search but rebuilt next time
                if (complete) _indexes[key] = index;
            }

            //Own title matches first, then items that match through their game (DLC, themes and pictures for "halo")
            List<TitleEntry> matches = index
                .Where(t => words.All(w => t.Searchable.Contains(w)))
                .OrderBy(t => t.Normalized.StartsWith(words[0], StringComparison.Ordinal) ? 0 : words.All(w => t.Normalized.Contains(w)) ? 1 : 2)
                .ThenBy(t => t.Title, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            if (matches.Count > 0) progress.Report("Loading " + Math.Min(matches.Count, MaxResults) + " of " + matches.Count + " matches…");
            List<XElement> entries = await FetchDetailsAsync(helper, matches.Take(MaxResults).Select(m => m.Id).ToList());
            return new SearchResult(entries, matches.Count, complete);
        }

        private static async Task<Tuple<List<TitleEntry>, bool>> BuildIndexAsync(Webhelper helper, IProgress<string> progress)
        {
            TimeSpan maxAge = helper.CacheMaxAge;
            string firstUrl = helper.BuildUrl(IndexPageSize.ToString(), "1", IndexDetailView);
            XDocument first = await FetchPageAsync(firstUrl, maxAge);
            if (first == null) throw new WebException("Xbox Live couldn't be reached to build the search index");

            int total = TotalItems(first);
            int pageCount = Math.Max(1, (int)Math.Ceiling(total / (double)IndexPageSize));
            var pages = new XDocument[pageCount];
            pages[0] = first;
            //Built here on the UI thread, the helper's settings can change while pages download
            List<string> urls = Enumerable.Range(2, pageCount - 1).Select(p => helper.BuildUrl(IndexPageSize.ToString(), p.ToString(), IndexDetailView)).ToList();

            int done = 1;
            progress.Report("Building search index: page 1 of " + pageCount + "…");
            using (var gate = new SemaphoreSlim(MaxParallel))
            {
                await Task.WhenAll(urls.Select(async (url, i) =>
                {
                    await gate.WaitAsync();
                    try
                    {
                        pages[i + 1] = await FetchPageAsync(url, maxAge);
                    }
                    finally
                    {
                        gate.Release();
                    }
                    progress.Report("Building search index: page " + Interlocked.Increment(ref done) + " of " + pageCount + "…");
                }));
            }

            var index = new List<TitleEntry>(total);
            foreach (XDocument page in pages.Where(p => p != null))
            {
                foreach (XElement entry in page.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "entry"))
                {
                    string id = entry.Element(Constants.NetworkConnectivity.Namespaces.Atom + "id")?.Value;
                    if (id == null || id.Length <= 9) continue;
                    //Many themes and gamer pictures carry no title of their own, only the game they belong to
                    string title = entry.Element(Constants.NetworkConnectivity.Namespaces.Atom + "title")?.Value
                                   ?? entry.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "reducedTitle").FirstOrDefault()?.Value
                                   ?? "";
                    string game = entry.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameReducedTitle").FirstOrDefault()?.Value ?? "";
                    index.Add(new TitleEntry(id.Substring(9), title, game));
                }
            }
            return Tuple.Create(index, pages.All(p => p != null));
        }

        private static async Task<List<XElement>> FetchDetailsAsync(Webhelper helper, List<string> ids)
        {
            TimeSpan maxAge = helper.CacheMaxAge;
            var batches = new List<List<string>>();
            for (int i = 0; i < ids.Count; i += DetailBatchSize)
            {
                batches.Add(ids.Skip(i).Take(DetailBatchSize).ToList());
            }

            var found = new Dictionary<string, XElement>(StringComparer.OrdinalIgnoreCase);
            using (var gate = new SemaphoreSlim(MaxParallel))
            {
                List<XElement>[] results = await Task.WhenAll(batches.Select(batch => FetchBatchAsync(helper, batch, maxAge, gate)));
                foreach (XElement entry in results.SelectMany(r => r))
                {
                    string id = entry.Element(Constants.NetworkConnectivity.Namespaces.Atom + "id")?.Value;
                    if (id != null && id.Length > 9) found[id.Substring(9)] = entry;
                }
            }
            //Keep the ranking, the server returns each batch in its own order
            return ids.Where(found.ContainsKey).Select(id => found[id]).ToList();
        }

        //One broken item makes Xbox Live fail the whole request (HTTP 500), so a failed batch is split
        //until the broken items are on their own and everything else still loads
        private static async Task<List<XElement>> FetchBatchAsync(Webhelper helper, List<string> batch, TimeSpan maxAge, SemaphoreSlim gate)
        {
            string url = helper.BuildUrl(batch.Count.ToString(), "1", helper.DetailView, batch);
            XDocument page;
            await gate.WaitAsync();
            try
            {
                page = await FetchPageAsync(url, maxAge);
            }
            finally
            {
                gate.Release();
            }
            if (page != null) return page.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "entry").ToList();
            if (batch.Count == 1) return new List<XElement>();
            int half = batch.Count / 2;
            List<XElement>[] parts = await Task.WhenAll(
                FetchBatchAsync(helper, batch.Take(half).ToList(), maxAge, gate),
                FetchBatchAsync(helper, batch.Skip(half).ToList(), maxAge, gate));
            return parts.SelectMany(p => p).ToList();
        }

        //One retry, the catalogue occasionally drops a request when many are in flight
        private static async Task<XDocument> FetchPageAsync(string url, TimeSpan maxAge)
        {
            XDocument page = (await Task.Run(() => Webhelper.FetchCatalogue(url, maxAge))).Page;
            if (page != null) return page;
            await Task.Delay(1000);
            return (await Task.Run(() => Webhelper.FetchCatalogue(url, maxAge))).Page;
        }

        private static int TotalItems(XDocument page)
        {
            int total;
            string value = page.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "totalItems").FirstOrDefault()?.Value;
            return int.TryParse(value, out total) ? total : 0;
        }

        //Lower case letters and digits only, so "collectors edition" finds "Collector's Edition" and ™ or ® don't matter
        private static string Normalize(string text)
        {
            var sb = new StringBuilder(text.Length);
            bool space = false;
            foreach (char c in text.Normalize(NormalizationForm.FormKC).ToLower(CultureInfo.InvariantCulture))
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                    space = false;
                }
                else if (char.IsWhiteSpace(c) || c == '-' || c == ':' || c == '_' || c == '/')
                {
                    if (!space && sb.Length > 0) sb.Append(' ');
                    space = true;
                }
            }
            return sb.ToString().Trim();
        }

        private class TitleEntry
        {
            public TitleEntry(string id, string title, string game)
            {
                Id = id;
                Title = title;
                Normalized = Normalize(title);
                Searchable = Normalize(title + " " + game);
            }

            public string Id { get; }
            public string Title { get; }
            public string Normalized { get; }
            //Title plus the game it belongs to
            public string Searchable { get; }
        }
    }

    public class SearchResult
    {
        public SearchResult(List<XElement> entries, int totalMatches, bool indexComplete)
        {
            Entries = entries;
            TotalMatches = totalMatches;
            IndexComplete = indexComplete;
        }

        public List<XElement> Entries { get; }
        public int TotalMatches { get; }
        public bool IndexComplete { get; }
    }
}
