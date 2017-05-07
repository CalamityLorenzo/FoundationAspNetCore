using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BooksCatalogueDb.Database;

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

        public IEnumerable<IBook> GetAllBooksInfo()
        {
            return MapAllFromDb(DbEnties.AsNoTracking()).ToList();
        }

        public IEnumerable<IBook> GetAllBooksForAuthor(IAuthor author)
        {
            var BookAuthors = ctx.Set<BookAuthor>();
            return this.MapAllFromDb(
                    BookAuthors.Include(o => o.Author)
                    .Where(o => o.Author == author)
                    .Select(o => o.Book)).ToList();
        }

        public IEnumerable<IBook> GetAllBooksForPublisher(IPublisher publisher)
        {
            return this.MapAllFromDb(DbEnties.Where(o => o.OriginalPublisherId == publisher.Id)).ToList();
        }

        //public IEnumerable<IEdition> GetEditionsForBook(IBook Book)
        //{
        //    return this.MappAllFromDb(DbEnties.Include(o=>o.Editions).Where(o => o.Id == Book.Id).Select(o=>o.Editions).ToList();
        //}

        //public IEnumerable<IEdition> GetEditionsForBook(int BookId)
        //{

        //}

    }
}
