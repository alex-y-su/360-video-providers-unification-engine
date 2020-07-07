using FulldiveVRVideoProvidersUnifyEngine;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using FulldiveVRVideoProvidersUnifyEngine.Data;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;
using Xunit.Abstractions;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class HtmlBasedVideoProviderTests
    {
        private readonly ITestOutputHelper _output;
        
        private static HtmlSiteProviderConfig config = new HtmlSiteProviderConfig(
            "https://www.pornhub.com/vr?page={0}",
            "https://www.pornhub.com{0}", 
            "#videoCategory > li.pcVideoListItem div.phimage > a",
            "#videoCategory > li.pcVideoListItem div.phimage > a > img",
            "#videoCategory > li.pcVideoListItem span.title > a"
        );

        private readonly SiteCrawler _crawler = new SiteCrawler(config, new HtmlDocumentTransport());
        
        public HtmlBasedVideoProviderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetVideoItemsFromPageTest()
        {
            var provider = new HtmlBasedVideoProvider(config, _crawler);
            var res = provider.GetVideos(2);
            foreach (var videoItemData in res)
            {
                _output.WriteLine(videoItemData.ToString());
            }
            Assert.Equal(44, res.Count); 
        }
    }
}