using System;
using System.Collections.Generic;

namespace FulldiveVRVideoProvidersUnifyEngine
{
    public interface IDocumentInterface
    {
        IEnumerable<string> GetLinksByCssQuery(string query);
        
        IEnumerable<string> GetTitlesByCssQuery(string query);
        
        IEnumerable<string> GetImagesByCssQuery(string query);
    }
}