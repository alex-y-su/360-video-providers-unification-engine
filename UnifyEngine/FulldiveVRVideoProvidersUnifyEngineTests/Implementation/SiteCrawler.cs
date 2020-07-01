using FulldiveVRVideoProvidersUnifyEngine;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    class SiteCrawler: ISiteCrawler
    {
        private readonly HtmlSiteProviderConfig _config;
        private readonly IHtmlDocumentTransport _htmlDocumentTransport;

        public SiteCrawler(HtmlSiteProviderConfig config, IHtmlDocumentTransport htmlDocumentTransport)
        {
            _config = config;
            _htmlDocumentTransport = htmlDocumentTransport;
        }

        public IDocumentInterface GetListPage(uint pageNumber)
        {
            var pageUrl = string.Format(this._config.PaginationUrlTemplate, pageNumber);
            return this._htmlDocumentTransport.GetDocumentByUrl(pageUrl);
        }

        public uint? GetPagesCount()
        {
            return 78;
        }
    }
}