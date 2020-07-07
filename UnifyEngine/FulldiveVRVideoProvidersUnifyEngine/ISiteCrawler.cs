using System.Collections.Generic;

namespace FulldiveVRVideoProvidersUnifyEngine
{
    public interface ISiteCrawler
    {
        IDocumentInterface GetListPage(uint pageNumber);
        uint? GetPagesCount();
    }
}