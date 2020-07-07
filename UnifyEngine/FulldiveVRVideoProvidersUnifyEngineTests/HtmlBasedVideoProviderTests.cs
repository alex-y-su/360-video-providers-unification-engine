using FulldiveVRVideoProvidersUnifyEngine;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;
using Xunit.Abstractions;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class HtmlBasedVideoProviderTests
    {
        private readonly ITestOutputHelper _output;
        
        public HtmlBasedVideoProviderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetVideoItemsFromPageTest()
        {
            var configData = new HtmlSiteProviderConfigData(
                "https://www.pornhub.com/vr?page={0}",
                "https://www.pornhub.com{0}", 
                "#videoCategory > li.pcVideoListItem div.phimage > a",
                "#videoCategory > li.pcVideoListItem div.phimage > a > img",
                "#videoCategory > li.pcVideoListItem span.title > a"
            );

            var crawler = new SiteCrawler(configData, new HtmlDocumentTransport());
            
            var provider = new HtmlBasedVideoProvider(configData, crawler);
            var res = provider.GetVideos(2);
            foreach (var videoItemData in res)
            {
                _output.WriteLine(videoItemData.ToString());
            }
            Assert.Equal(44, res.Count); 
        }
        
        [Fact]
        public void GetVideoItemsFromPage2Test()
        {
            var configData = new HtmlSiteProviderConfigData(
                "https://vimeo.com/channels/360vr/videos/page:{0}/sort:preset",
                "https://vimeo.com{0}", 
                "ol.js-browse_list > li > a",
                "ol.js-browse_list > li > a > img",
                "ol.js-browse_list > li > a div.l-ellipsis"
            );

            var crawler = new SiteCrawler(configData, new HtmlDocumentTransport());
            
            var provider = new HtmlBasedVideoProvider(configData, crawler);
            var res = provider.GetVideos(2);
            foreach (var videoItemData in res)
            {
                _output.WriteLine(videoItemData.ToString());
            }
            Assert.Equal(12, res.Count); 
        }
    }
}