namespace FulldiveVRVideoProvidersUnifyEngine.Configs
{
    // marker
    public interface IProviderConfigData {}
    
    public abstract class ProviderConfig<T> where T: IProviderConfigData{
        public string Title { get; set; }
        public ProviderConfigType ProviderType { get; set; }
        public abstract T ConfigData { get; set; }
    }
}