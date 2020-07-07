namespace FulldiveVRVideoProvidersUnifyEngine.Configs
{
    public class HtmlSiteProviderConfig
    {
        public string PaginationUrlTemplate { get; }
        public string VideoPageUrlTemplate { get; }
        public string LinksCssSelector { get; }
        public string ImagesCssSelector { get; }
        public string TitlesCssSelector { get; }
        public uint? PagesCount { get; set; }

        public HtmlSiteProviderConfig(
            string paginationUrlTemplate, 
            string videoPageUrlTemplate, 
            string linksCssSelector, 
            string imagesCssSelector, 
            string titlesCssSelector,
            uint? pagesCount = null)
        {
            PaginationUrlTemplate = paginationUrlTemplate;
            VideoPageUrlTemplate = videoPageUrlTemplate;
            LinksCssSelector = linksCssSelector;
            ImagesCssSelector = imagesCssSelector;
            TitlesCssSelector = titlesCssSelector;
            PagesCount = pagesCount;
        }
    }
}