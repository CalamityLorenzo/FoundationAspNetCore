using BooksCatalogueDb.Application;
using BooksCatalogueDb.BookInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalogueDb.Books
{

    // Get's  the info about AUthors
    public class AuthorsCatalogueShoes
    {
        BooksCatalogueContext ctx;
        public AuthorsCatalogueShoes()
        {
            this.ctx = DatabaseConfig.GetContext();
            if (ctx == null)
                throw new ArgumentNullException("Somethings gone wrong");
        }

        #region Basics
        public void Add(IAuthor newAuthor)
        {
            CreateAuthor(newAuthor);
            ctx.SaveChanges();
        }
        public async Task AddAsync(IAuthor newAuthor)
        {
            CreateAuthor(newAuthor);
            await ctx.SaveChangesAsync();
        }

        public IAuthor Get(int id)
        {
            return Author.MapFromDb(ctx.Authors.Single(o => o.Id == id));
        }
        public async Task Update(IAuthor author)
        {
            ctx.Authors.Update(Author.MapToDb(author));
            await ctx.SaveChangesAsync();
        }


        #endregion
        private void CreateAuthor(IAuthor newAuthor)
        {
            var newAuthorDb = Author.MapToDb(newAuthor);
            ctx.Authors.Add(newAuthorDb);
        }



    }

    public class AuthorsCatalogue : BaseRepository<AuthorDb, IAuthor>
    {
        internal AuthorsCatalogue(DbContext ctx) : base(ctx)
        {
        }

        internal override Func<AuthorDb, IAuthor> MapFromDb => Author.MapFromDb;
        internal override Func<IAuthor, AuthorDb> MapToDb => Author.MapToDb;

        public AuthorsCatalogue():base() { }

        public IEnumerable<IGrouping<char, IAuthor>> AuthorsGroupedByName()
        {
            // Simply grouped by the first character of tehir last name
            var GrpdAutors = MappAllFromDb(DbEnties).GroupBy(o => o.LastName.First());
            return GrpdAutors.ToList();
        }


        public IEnumerable<IAuthor> FindAuthorByBook(IBook Book)
        {
            // An Anomoly
            var BookAndAuthors = ctx.Set<BookAuthor>();


            var BookAuthorList = BookAndAuthors.Include(o=>o.Author).Where(ba => ba.Book == Book);
            return BookAuthorList.Select(o => this.MapFromDb(o.Author));
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
