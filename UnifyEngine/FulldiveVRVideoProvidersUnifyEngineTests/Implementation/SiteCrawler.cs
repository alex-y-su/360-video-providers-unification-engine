using FulldiveVRVideoProvidersUnifyEngine;
using FulldiveVRVideoProvidersUnifyEngine.Configs;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    class SiteCrawler: ISiteCrawler
    {
        private readonly HtmlSiteProviderConfigData _configData;
        private readonly IHtmlDocumentTransport _htmlDocumentTransport;

        public SiteCrawler(HtmlSiteProviderConfigData configData, IHtmlDocumentTransport htmlDocumentTransport)
        {
            _configData = configData;
            _htmlDocumentTransport = htmlDocumentTransport;
        }

        public IDocumentInterface GetListPage(uint pageNumber)
        {
            var pageUrl = string.Format(this._configData.PaginationUrlTemplate, pageNumber);
            return _htmlDocumentTransport.GetDocumentByUrl(pageUrl);
        }

        public uint? GetPagesCount()
        {
            return _configData.PagesCount;
        }
    }
}