using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IEditionFile 
    {
         string FileType { get;  }
         string FileUrl { get;  }
         string FileFormat { get;  }
    }
}
