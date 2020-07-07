using System.Collections.Generic;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using Newtonsoft.Json;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    public class ProviderConfigParser
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        };
        
        public ProviderConfigParser()
        {
            _jsonSettings.Converters.Add(new ProvidersConfigJsonConverter());
        }
        
        public List<ProviderConfig> Parse(string jsonData)
        {
            var topLevel = JsonConvert.DeserializeObject<ProvidersList>(jsonData, _jsonSettings);
            return topLevel.Providers;
        }
    }
}