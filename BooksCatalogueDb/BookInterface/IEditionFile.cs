using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IEditionFile :IBaseEntity
    {
            int EditionId { get; }
        string Title { get; }
         string Type { get;  }
         string Url { get;  }
         string Format { get;  }
    }
}
