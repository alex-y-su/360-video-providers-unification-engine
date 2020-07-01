using System.Net;
using FulldiveVRVideoProvidersUnifyEngine;
using HtmlAgilityPack;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    class HtmlDocumentTransport: IHtmlDocumentTransport
    {
        public IDocumentInterface GetDocumentByUrl(string url)
        {
            var htmlWeb = new HtmlWeb();
            var doc = htmlWeb.Load(url);
            return htmlWeb.StatusCode != HttpStatusCode.OK ? null : new DocumentInterface(doc);
        }
    }
}