namespace FulldiveVRVideoProvidersUnifyEngine.Configs
{
    public abstract class ProviderConfig{
        public string Title { get; set; }
        
        public string Image { get; set; }
        public ProviderConfigType ProviderType { get; set; }
    }

    public class HtmlBasedProviderConfig : ProviderConfig
    {
        public HtmlSiteProviderConfigData ConfigData { get; set; }
    }
}