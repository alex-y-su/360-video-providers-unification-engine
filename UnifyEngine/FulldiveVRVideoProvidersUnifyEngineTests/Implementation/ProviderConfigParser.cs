using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FulldiveVRVideoProvidersUnifyEngine.Configs;
using Newtonsoft.Json;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    /*https://alexeysuvorov.github.io/files/providers.json
     
{
  "schema": "v1",
  "providers": [
    {
      "title": "Hub",
      "providerType": "html",
      "data": {
        "paginationUrlTemplate": "https://www.pornhub.com/vr?page={0}",
        "videoPageUrlTemplate": "https://www.pornhub.com{0}",
        "linksCssSelector": "#videoCategory > li.pcVideoListItem div.phimage > a",
        "imagesCssSelector": "#videoCategory > li.pcVideoListItem div.phimage > a > img",
        "titlesCssSelector": "#videoCategory > li.pcVideoListItem span.title > a",
        "pagesCount": 79
      }
    }
  ]
}
*/
    
    public class ConfigConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // readonly
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // serializer.Deserialize()
                
            // var type = reader.Value;
            //throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ProviderConfig<>);
        }
    }

    public class ProvidersList
    {
        public string Schema { get; set; }
        public ProviderConfig<IProviderConfigData>[] Providers { get; set; }
    }
    
    public class ProviderConfigParser
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            
        };
        
        public ProviderConfigParser()
        {
            _jsonSettings.Converters.Add(new ConfigConverter());
            
            // 
            // var objectToSerialize = new {Property1 = "value1", SubOjbect = new { SubObjectId = 1 }};
            // var json = Newtonsoft.Json.JsonConvert.SerializeObject(data, );
        }
        
        public List<ProviderConfig<IProviderConfigData>> Parse(string jsonData)
        {
            var topLevel = JsonConvert.DeserializeObject<ProvidersList>(jsonData, _jsonSettings);
            return new List<ProviderConfig<IProviderConfigData>>(); 
        }
    }
}