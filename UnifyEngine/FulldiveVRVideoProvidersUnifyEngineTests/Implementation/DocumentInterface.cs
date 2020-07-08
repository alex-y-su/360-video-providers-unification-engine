using System;
using System.Collections.Generic;
using System.Linq;
using FulldiveVRVideoProvidersUnifyEngine;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace FulldiveVRVideoProvidersUnifyEngineTests.Implementation
{
    class DocumentInterface: IDocumentInterface
    {
        private readonly HtmlDocument _htmlDocument;
        private string[] _possibleImageUrlAttributeName = new string[] { "src", "data-src" };

        public DocumentInterface(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            _htmlDocument = htmlDocument;
        }

        public IEnumerable<string> GetLinksByCssQuery(string query)
        {
            return this._htmlDocument.DocumentNode.CssSelect(query)
                .Where(x => x != null && x.HasAttributes)
                .Select(x => x.GetAttributeValue("href"));
        }

        public IEnumerable<string> GetTitlesByCssQuery(string query)
        {
            return this._htmlDocument.DocumentNode.CssSelect(query)
                .Select(x => x.InnerText);
        }

        public IEnumerable<string> GetImagesByCssQuery(string query)
        {
            return this._htmlDocument.DocumentNode.CssSelect(query)
                .Where(x => x != null && x.HasAttributes)
                .Select(x => GetUrlImageArributeValue(x, _possibleImageUrlAttributeName);
        }

        private string GetUrlImageArributeValue(HtmlNode htmlNode, string[] altAttributeNames)
        {
            string attributeValue = string.Empty;
            for (int i = 0; i < altAttributeNames.Length; i++)
            {
                attributeValue = htmlNode.GetAttributeValue(altAttributeNames[i], string.Empty);
                if (Uri.TryCreate(attributeValue, UriKind.Absolute, out Uri uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    return attributeValue;
                }
            }
            return string.Empty;
        }
    }
}