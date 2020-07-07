using System.IO;
using FulldiveVRVideoProvidersUnifyEngineTests.Implementation;
using Xunit;
using Xunit.Abstractions;

namespace FulldiveVRVideoProvidersUnifyEngineTests
{
    public class ProviderConfigParserTests
    {
        private readonly ITestOutputHelper _output;

        public ProviderConfigParserTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ParseProvidersTest()
        {
            var fileContent = File.ReadAllText("Data/providers.json");
            var parser = new ProviderConfigParser();
            var res = parser.Parse(fileContent);
            foreach (var providerConfig in res)
            {
                _output.WriteLine(providerConfig.ToString());
            }
        }
    }
}