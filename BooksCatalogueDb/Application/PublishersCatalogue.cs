using BooksCatalogueDb.BookInterface;
using BooksCatalogueDb.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalogueDb.Application
{
    public class PublishersCatalogue : BaseRepository<PublisherDb, IPublisher>
    {
        
        public PublishersCatalogue()
        {
        }

        internal PublishersCatalogue(DbContext ctx) : base(ctx)
        {
        }
    }
}
