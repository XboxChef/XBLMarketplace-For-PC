using System;
using System.Net;
using System.Threading.Tasks;

namespace XBLMarketplace_For_PC.FormComponents
{
    class ExtendedClient : WebClient
    {
        private bool _supportsResume;
        private bool checkedresume = false;

        public ExtendedClient(string useragent = null)
        {
            if (useragent != null)
            {
                if (Headers != null) Headers.Add("user-agent", useragent);
            }
        }

        public bool HeadOnly { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            if (HeadOnly && req.Method == "GET")
            {
                req.Method = "HEAD";
            }
            return req;
        }

        public async Task<bool> SupportsResume(string address)
        {
            if (checkedresume) return _supportsResume;
            HeadOnly = true;
            if (ResponseHeaders == null) await DownloadStringTaskAsync(address);
            if (ResponseHeaders?.Get("Accept-Ranges") != null)
            {
                _supportsResume = true;
            }
            checkedresume = true;
            return _supportsResume;
        }

        internal void DownloadStringAsync(string address, bool isCanceled)
        {DownloadStringAsync(new Uri(address), isCanceled);}

        internal void DownloadStringAsync(string address)
        { DownloadStringAsync(new Uri(address)); }
    }
}