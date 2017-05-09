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
        private EditionFilesCatalogue EditionFilesCatalogueData;
        internal EditionsCatalouge(DbContext ctx) : base(ctx)
        {
            EditionFilesCatalogueData = new EditionFilesCatalogue(ctx);
        }
        public EditionsCatalouge() : base()
        {
            EditionFilesCatalogueData = new EditionFilesCatalogue();
        }


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
        // SUB CLASS! //
        class EditionFilesCatalogue : BaseRepository<EditionFileDb, IEditionFile>
        {
            internal EditionFilesCatalogue(DbContext ctx) : base(ctx) { }
            public EditionFilesCatalogue() : base() { }
            internal override Func<EditionFileDb, IEditionFile> MapFromDb => EditionFile.MapFromDb;
            internal override Func<IEditionFile, EditionFileDb> MapToDb => EditionFile.MapToDb;

            public IEnumerable<IEditionFile> GetFilesForEdition(int editionId)
            {
                return this.MapAllFromDb(DbEnties.Where(o => o.Id == editionId));
            }
            public IEnumerable<IEditionFile> GetFilesForEdition(IEdition edition)
            {
                if (edition.Id == 0)
                {
                    throw new ArgumentOutOfRangeException("You must have an Id");
                }

                return GetFilesForEdition(edition.Id);
            }

        }
    }
}
