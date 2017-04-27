using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BooksCatalogueDb.Application
{
    public class BooksCatalogue : BaseRepository<BookDb, IBook>
    {
        internal BooksCatalogue(DbContext ctx) : base(ctx)
        {

        }

        public BooksCatalogue() : base() { }

        internal override Func<BookDb, IBook> MapFromDb => Book.MapFromDb;
        internal override Func<IBook, BookDb> MapToDb => Book.MapToDb;

        public IEnumerable<IBook> GetAllBookInfo()
        {
            return MappAllFromDb(DbEnties.AsNoTracking());
        }

        public IEnumerable<IBook> GetAllBooksForAuthor(IAuthor author)
        {
            var BookAuthors = ctx.Set<BookAuthor>();
            return this.MappAllFromDb(
                    BookAuthors.Include(o => o.Author)
                    .Where(o => o.Author == author)
                    .Select(o => o.Book));
        }

        public IEnumerable<IBook> GetAllBooksForPublisher(IPublisher publisher)
        {

        }

    }
}
