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
        private readonly HtmlSiteProviderConfigData _configData;
        private readonly ISiteCrawler _crawler;

        public HtmlBasedVideoProvider(HtmlSiteProviderConfigData configData, ISiteCrawler crawler)
        {
            _configData = configData;
            _crawler = crawler;
        }

        public IList<VideoItemData> GetVideos(uint page)
        {
            var doc = this._crawler.GetListPage(page);
            return EnumExtensions.ZipThree(
                doc.GetLinksByCssQuery(_configData.LinksCssSelector),
                doc.GetImagesByCssQuery(_configData.ImagesCssSelector),
                doc.GetTitlesByCssQuery(_configData.TitlesCssSelector),
                (l, i, t) => new VideoItemData { Image = i, Link = string.Format(_configData.VideoPageUrlTemplate, l), Title = t }
            ).ToList();
        }
    }
}