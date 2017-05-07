using BooksCatalogueDb.BookInterface;
using BooksCatalogueDb.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalogueDb.Application
{
    public class EditionsCatalouge : BaseRepository<EditionDb, IEdition>
    {
        internal EditionsCatalouge(DbContext ctx) : base(ctx){}
        public EditionsCatalouge():base() { }

        internal override Func<EditionDb, IEdition> MapFromDb => Edition.MapFromDb;
        internal override Func<IEdition, EditionDb> MapToDb => Edition.MapToDb;

        public IEnumerable<IEdition> GetEditionsForBook(IBook book)
        {
            return GetEditionsForBook(book.Id);
        }

        public IEnumerable<IEdition> GetEditionsForBook(int bookId)
        {
            var itms = this.DbEnties.Include(o => o.EditionFiles).Where(o => o.BookId == bookId);
            return this.MapAllFromDb(itms);
        }

        async void Update(IEnumerable<IEdition> Editions)
        {
            await Task.WhenAll(Editions.ToList().Select(async o => await Update(o)));
        }

    }
}
