using System;
using System.Collections.Generic;

namespace FulldiveVRVideoProvidersUnifyEngine
{
    public class VideoItemData
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
    
    public class HtmlBasedVideoProvider
    {
        public HtmlBasedVideoProvider(HtmlSiteProviderConfig config, ISiteCrawler crawler)
        {
        }

        public IList<VideoItemData> GetVideos(int count, int skip)
        {
            return new List<VideoItemData>();
        }
    }
    
    public interface ISiteCrawler
    {
        IDocumentInterface GetListPage(uint pageNumber);
        uint? GetPagesCount();
    }
}