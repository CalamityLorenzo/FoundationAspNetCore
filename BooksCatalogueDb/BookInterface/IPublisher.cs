using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.BookInterface
{
    public interface IPublisher : IBaseEntity
    {
         string Name { get;  }
         int YearStarted { get;  }
         string Bio { get;  }
    }
}
