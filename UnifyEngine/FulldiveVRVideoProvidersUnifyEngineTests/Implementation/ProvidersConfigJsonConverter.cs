using System;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    public class ProvidersConfigJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // readonly
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JObject>(reader);
            var type = obj.GetValue("providerType").ToString();
            switch (type)
            {
                case "html":
                    var dataReader = obj.GetValue("data").CreateReader();
                    var data = serializer.Deserialize<HtmlSiteProviderConfigData>(dataReader);
                    return new HtmlBasedProviderConfig
                    {
                        ConfigData = data,
                        Title = obj.GetValue("title").ToString(),
                        ProviderType = ProviderConfigType.HtmlPage
                    };
                    break;
                default:
                    throw new ArgumentException($"Provider config of type {type} is not supported");
                
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProviderConfig);
        }
    }
}