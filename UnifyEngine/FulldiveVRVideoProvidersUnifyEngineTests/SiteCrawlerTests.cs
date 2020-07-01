using System;
using FulldiveVRVideoProvidersUnifyEngine;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;
using Xunit.Abstractions;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class SiteCrawlerTests
    {
        ITestOutputHelper _output;

        private static HtmlSiteProviderConfig config = new HtmlSiteProviderConfig("https://www.pornhub.com/vr?page={0}",
            "https://www.pornhub.com{0}", "#videoCategory > li.pcVideoListItem div.phimage > a");
        
        private SiteCrawler _crawler = new SiteCrawler(config, new HtmlDocumentTransport());

        public SiteCrawlerTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void GetListPageTest()
        {
            var page2doc = _crawler.GetListPage(2);
            var res = page2doc.GetLinksByCssQuery(config.LinksCssSelector);
            foreach (var re in res)
            {
                _output.WriteLine(re);
            }
        }

        [Fact]
        public void ShouldReturnNullWhenThereIsNoPageTest()
        {
            var page = this._crawler.GetListPage(10500);
            Assert.Null(page);
        }
    }
}