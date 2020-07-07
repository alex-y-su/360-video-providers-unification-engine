using System;
using System.Collections.Generic;
using System.Linq;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using FulldiveVRVideoProvidersUnifyEngine.Data;
using FulldiveVRVideoProvidersUnifyEngine.Extensions;

namespace FulldiveVRVideoProvidersUnifyEngine
{
    public class HtmlBasedVideoProvider
    {
        private readonly HtmlSiteProviderConfig _config;
        private readonly ISiteCrawler _crawler;

        public HtmlBasedVideoProvider(HtmlSiteProviderConfig config, ISiteCrawler crawler)
        {
            _config = config;
            _crawler = crawler;
        }

        public IList<VideoItemData> GetVideos(uint page)
        {
            var doc = this._crawler.GetListPage(page);
            return EnumExtensions.ZipThree(
                doc.GetLinksByCssQuery(_config.LinksCssSelector),
                doc.GetImagesByCssQuery(_config.ImagesCssSelector),
                doc.GetTitlesByCssQuery(_config.TitlesCssSelector),
                (l, i, t) => new VideoItemData { Image = i, Link = string.Format(_config.VideoPageUrlTemplate, l), Title = t }
            ).ToList();
        }
    }
}