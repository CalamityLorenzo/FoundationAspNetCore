using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IEditionFile :IBaseEntity
    {
            int EditionId { get; }
         string FileType { get;  }
         string FileUrl { get;  }
         string FileFormat { get;  }
    }
}
