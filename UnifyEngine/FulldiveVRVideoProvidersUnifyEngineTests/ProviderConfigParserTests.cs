using System.IO;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class ProviderConfigParserTests
    {
        [Fact]
        public void ParseProviders2Test()
        {
            var fileContent = File.ReadAllText("Data/providers-2.json");
            var parser = new ProviderConfigParser();
            var res = parser.Parse(fileContent);
            Assert.Equal(2,res.Count);
        }
        
        [Fact]
        public void ParseProvidersTest()
        {
            var fileContent = File.ReadAllText("Data/providers.json");
            var parser = new ProviderConfigParser();
            var res = parser.Parse(fileContent);
            Assert.Equal(1,res.Count);
            var x = res[0] as HtmlBasedProviderConfig;
            Assert.Equal("Hub", x.Title);
            Assert.Equal(ProviderConfigType.HtmlPage, x.ProviderType);
            Assert.Equal(79u, x.ConfigData.PagesCount);
            Assert.Equal("#videoCategory > li.pcVideoListItem div.phimage > a > img", x.ConfigData.ImagesCssSelector);
            Assert.Equal("#videoCategory > li.pcVideoListItem div.phimage > a", x.ConfigData.LinksCssSelector);
            Assert.Equal("#videoCategory > li.pcVideoListItem span.title > a", x.ConfigData.TitlesCssSelector);
            Assert.Equal("https://www.pornhub.com{0}", x.ConfigData.VideoPageUrlTemplate);
            Assert.Equal("https://www.pornhub.com/vr?page={0}", x.ConfigData.PaginationUrlTemplate);
        }
    }
}