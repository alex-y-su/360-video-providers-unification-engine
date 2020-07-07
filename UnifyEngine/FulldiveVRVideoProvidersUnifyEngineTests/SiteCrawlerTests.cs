using FulldiveVRVideoProvidersUnifyEngine.Configs;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;
using Xunit.Abstractions;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class SiteCrawlerTests
    {
        private static readonly HtmlSiteProviderConfigData ConfigData = new HtmlSiteProviderConfigData(
            "https://www.pornhub.com/vr?page={0}",
            "https://www.pornhub.com{0}", 
            "#videoCategory > li.pcVideoListItem div.phimage > a",
            "#videoCategory > li.pcVideoListItem div.phimage > a > img",
            "#videoCategory > li.pcVideoListItem span.title > a"
        );
        
        private readonly ITestOutputHelper _output;
        private readonly SiteCrawler _crawler = new SiteCrawler(ConfigData, new HtmlDocumentTransport());

        public SiteCrawlerTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void GetListPageTest()
        {
            var page2doc = _crawler.GetListPage(2);
            var res = page2doc.GetLinksByCssQuery(ConfigData.LinksCssSelector);
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