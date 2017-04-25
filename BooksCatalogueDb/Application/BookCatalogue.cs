using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalogueDb.Application
{
    public class BookCatalogue
    {
        BooksCatalogueContext ctx;

        public BookCatalogue()
        {
            this.ctx = DatabaseConfig.GetContext();
        }

        public IEnumerable<IBook> GetBooks()
        {
            return ctx.Books.Include(o=>o.OriginalPublisher).Select(o => Book.MapFromDb(o)).ToList();
        }
    }
}
