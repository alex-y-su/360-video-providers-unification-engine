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
                .Select(x => x.GetAttributeValue("src"));
        }
    }
}