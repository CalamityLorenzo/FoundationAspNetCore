using BooksCatalogueDb.Application;
using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalogueDb.Books
{

    // Get's  the info about AUthors
    public class AuthorsCatalogue
    {
        BooksCatalogueContext ctx;
        public AuthorsCatalogue()
        {
            this.ctx = DatabaseConfig.GetContext();
            if (ctx == null)
                throw new ArgumentNullException(" Somethings gone wrong");
        }

        public IEnumerable<IGrouping<char, IAuthor>> AuthorsGroupedByName()
        {
            var GrpdAutors = ctx.Authors.Select(i => Author.MapFromDb(i)).GroupBy(o => o.FirstName.First());
            return GrpdAutors.ToList();
        }

        private void CreateAuthor(IAuthor newAuthor)
        {
            var newAuthorDb = Author.MapToDb(newAuthor);
            ctx.Authors.Add(newAuthorDb);
        }

        public void AddAuthor(IAuthor newAuthor)
        {
            CreateAuthor(newAuthor);
            ctx.SaveChanges();
        }

        public async Task AddAuthorAsync(IAuthor newAuthor)
        {
            CreateAuthor(newAuthor);
            await ctx.SaveChangesAsync();
        }

        public IEnumerable<IAuthor> FindAuthorByBook(IBook Book)
        {
            var BookAuthorList = ctx.BookAuthors.Where(ba => ba.Book == Book);
            return BookAuthorList.Select(o => Author.MapFromDb(o.Author));
        }

        public IEnumerable<IAuthor> GetAuthor(string Name)
        {
            var name = Name.Split(new[] { ' ' });
            IEnumerable<AuthorDb> FoundAuthor = new List<AuthorDb>();
            if (name.Length == 2)
            {
                FoundAuthor = ctx.Authors.Where(a => a.FirstName.Equals(name[0], StringComparison.CurrentCultureIgnoreCase) && a.LastName.Equals(StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                FoundAuthor = ctx.Authors.Where(a => a.FirstName.Equals(name[0], StringComparison.CurrentCultureIgnoreCase));
            }
            return FoundAuthor.Select(o => Author.MapFromDb(o));

        }
        public IAuthor GetAuthor(int id)
        {
            return null;
        }

    }
}
