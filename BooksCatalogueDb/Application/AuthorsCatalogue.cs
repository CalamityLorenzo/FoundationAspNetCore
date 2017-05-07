using BooksCatalogueDb.Application;
using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksCatalogueDb.Database;

namespace BooksCatalogueDb.Application
{

    // Get's  the info about AUthors
  
    public class AuthorsCatalogue : BaseRepository<AuthorDb, IAuthor>
    {
        internal AuthorsCatalogue(DbContext ctx) : base(ctx)
        {
        }

        internal override Func<AuthorDb, IAuthor> MapFromDb => Author.MapFromDb;
        internal override Func<IAuthor, AuthorDb> MapToDb => Author.MapToDb;

        public AuthorsCatalogue():base() { }

        public IEnumerable<IGrouping<char, IAuthor>> AuthorsGroupedByLastName()
        {
            // Simply grouped by the first character of tehir last name
            var GrpdAutors = MapAllFromDb(DbEnties).GroupBy(o => o.LastName.First());
            return GrpdAutors.ToList();
        }


        public IEnumerable<IAuthor> FindAuthorByBook(IBook Book)
        {
            // An Anomoly
            var BookAndAuthors = ctx.Set<BookAuthor>();
            var BookAuthorList = BookAndAuthors.Include(o=>o.Author).Where(ba => ba.Book == Book);
            return BookAuthorList.Select(o => this.MapFromDb(o.Author));
        }

        public async Task AddToBook(IAuthor author, IBook book)
        {
            // see if they already exist
            var bAuthors = this.ctx.Set<BookAuthor>();
            if (bAuthors.FirstOrDefault(ba => ba.AuthorId == author.Id && ba.BookId == book.Id) == null)
            {
                bAuthors.Add(new BookAuthor { AuthorId = author.Id, BookId = book.Id });
                await ctx.SaveChangesAsync();
            }
        }

        public IEnumerable<IAuthor> Get(string Name)
        {
            // ALternative Get By NAme
            var name = Name.Split(new[] { ' ' });
            IEnumerable<AuthorDb> FoundAuthor = new List<AuthorDb>();
            if (name.Length >= 2)
            {
                FoundAuthor = DbEnties.Where(a => a.FirstName.Equals(name[0], StringComparison.CurrentCultureIgnoreCase) && a.LastName.Equals(StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                FoundAuthor = DbEnties.Where(a => a.FirstName.Equals(name[0], StringComparison.CurrentCultureIgnoreCase));
            }
            return FoundAuthor.Select(o => Author.MapFromDb(o));

        }
    }
}
