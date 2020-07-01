namespace FulldiveVRVideoProvidersUnifyEngine
{
    public class HtmlSiteProviderConfig
    {
        public string PaginationUrlTemplate { get; }

        public string VideoPageUrlTemplate { get; }
        
        public string LinksCssSelector { get; }

        public HtmlSiteProviderConfig(string paginationUrlTemplate, string videoPageUrlTemplate, string linksCssSelector)
        {
            PaginationUrlTemplate = paginationUrlTemplate;
            VideoPageUrlTemplate = videoPageUrlTemplate;
            LinksCssSelector = linksCssSelector;
        }
    }
}