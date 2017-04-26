using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BooksCatalogueDb.Application
{
    public class BookCatalogue : BaseRepository<BookDb, IBook>
    {
        public BookCatalogue(DbContext ctx) : base(ctx)
        {

        }

        public BookCatalogue() : base() { }

        internal override Func<BookDb, IBook> MapFromDb => Book.MapFromDb;
        internal override Func<IBook, BookDb> MapToDb => Book.MapToDb;

        public IEnumerable<IBook> GetAllBooksInfo()
        {
            return MappAllFromDb(DbEnties.AsNoTracking());
        }

    }
}
