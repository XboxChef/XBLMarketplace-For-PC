// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.FormComponents.ExtendedClient
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.Net;
using System.Threading.Tasks;

namespace XBLMarketplace_For_PC.FormComponents
{
  internal class ExtendedClient : WebClient
  {
    private bool _supportsResume;
    private bool checkedresume;

    public ExtendedClient(string useragent = null)
    {
      if (useragent == null || this.Headers == null)
        return;
      this.Headers.Add("user-agent", useragent);
    }

    public bool HeadOnly { get; set; }

    protected override WebRequest GetWebRequest(Uri address)
    {
      WebRequest webRequest = base.GetWebRequest(address);
      if (this.HeadOnly && webRequest.Method == "GET")
        webRequest.Method = "HEAD";
      return webRequest;
    }

    public async Task<bool> SupportsResume(string address)
    {
      ExtendedClient extendedClient = this;
      if (extendedClient.checkedresume)
        return extendedClient._supportsResume;
      extendedClient.HeadOnly = true;
      if (extendedClient.ResponseHeaders == null)
      {
        string str = await extendedClient.DownloadStringTaskAsync(address);
      }
      switch (extendedClient.ResponseHeaders?.Get("Accept-Ranges"))
      {
        case null:
          extendedClient.checkedresume = true;
          return extendedClient._supportsResume;
        default:
          extendedClient._supportsResume = true;
          goto case null;
      }
    }

    internal void DownloadStringAsync(string address, bool isCanceled) => this.DownloadStringAsync(new Uri(address), (object) isCanceled);

    internal void DownloadStringAsync(string address) => this.DownloadStringAsync(new Uri(address));
  }
}
