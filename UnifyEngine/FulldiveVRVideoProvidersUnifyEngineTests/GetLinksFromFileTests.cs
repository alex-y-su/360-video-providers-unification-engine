using System.Collections.Generic;
using System.IO;
using System.Linq;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using HtmlAgilityPack;
using Xunit;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class GetLinksFromFileTests
    {
        [Fact]
        public void GetLinksTest()
        {
            var fileContent = File.ReadAllText("Data/vr.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(fileContent);
            
            var docInterface = new DocumentInterface(doc);
            var res = docInterface.GetLinksByCssQuery("#videoCategory > li.pcVideoListItem div.phimage > a").ToArray();
            
            Assert.Equal(res, new List<string>
            {
                "/view_video.php?viewkey=ph5ef30590cc6f3",
                "/view_video.php?viewkey=ph5ef68e7ae2505",
                "/view_video.php?viewkey=ph5ebb2dad6dd97",
                "/view_video.php?viewkey=ph5e5e8af45d0ae",
                "/view_video.php?viewkey=ph5ee7df55702fc",
                "/view_video.php?viewkey=ph5ef10ebb89995",
                "/view_video.php?viewkey=ph5cda761263d21",
                "/view_video.php?viewkey=ph5e2a3c9e66f29",
                "/view_video.php?viewkey=ph5eeea49e8705a",
                "/view_video.php?viewkey=ph5de7e50f8eb6c",
                "/view_video.php?viewkey=ph5eebb82fbf99b",
                "/view_video.php?viewkey=ph5ee7509d893f2",
                "/view_video.php?viewkey=ph5d9751240ff7b",
                "/view_video.php?viewkey=ph5eef09d2e329b",
                "/view_video.php?viewkey=ph5e5e47dc50c7c",
                "/view_video.php?viewkey=ph5eeeb0228bea9",
                "/view_video.php?viewkey=ph5ee8d568a6696",
                "/view_video.php?viewkey=ph5eec4164e8080",
                "/view_video.php?viewkey=ph5eee0e5ec2b54",
                "/view_video.php?viewkey=ph5eaaae3742891",
                "/view_video.php?viewkey=ph5eec9bc959756",
                "/view_video.php?viewkey=ph5eb14839a343f",
                "/view_video.php?viewkey=ph5eceb106501b7",
                "/view_video.php?viewkey=ph5eeba83b8e45d",
                "/view_video.php?viewkey=ph5ef0a5b8af2d5",
                "/view_video.php?viewkey=ph5eef210de5ad5",
                "/view_video.php?viewkey=ph5eec61d9606c3",
                "/view_video.php?viewkey=ph5eec2d7867c85",
                "/view_video.php?viewkey=ph5eeb05cd560d3",
                "/view_video.php?viewkey=ph5eb6fdf1ba383",
                "/view_video.php?viewkey=ph5ed512d8bc1c6",
                "/view_video.php?viewkey=ph5dbb9441b8645"
            });
        }
    }
}