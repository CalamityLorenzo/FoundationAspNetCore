using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    interface IEditionFile 
    {
         string FileType { get;  }
         string FileUrl { get;  }
         string FileFormat { get;  }
    }
}
