using System;
using BooksCatalogueDb;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using BooksCatalogueDb.Application;
using BooksCatalogueDb.BookInterface;

namespace DbTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThings().Wait();
        }

        static async Task DoThings()
        {
            BooksCatalogue bc = new BooksCatalogue();
            var books = bc.GetAllBooksInfo();

            AuthorsCatalogue Ac = new AuthorsCatalogue();
            var names = Ac.AuthorsGroupedByLastName();
            
            using(var bookBomb= new BooksDatabaseApp())
            {

            }

            //Ac.Add(new ClientAuthor
            //{
            //    FirstName = "Paul",
            //    LastName = "Lawrence",
            //    ThumbNailUrl = "",
            //    YearOfBirth = 1978,
            //    Bio = "Widdle, Fiddle"
            //});

            //names.SelectMany(d => d).ToList().ForEach(Console.WriteLine);
            //Ac.Add(new ClientAuthor { FirstName = "Claude", LastName = "PoundHammer", YearOfBirth = 1987, Bio="Watrnifn", ThumbNailUrl="" });
             //bc.Add(new ClientBook { Genre = (BookGenre)1025, Name = "JEnny the Book", OriginalPublisherId=1,  Synopsis = "", YearFirst = 1835 });
        }

        class ClientBook : IBook
        {
            public string Name { get; set; }

            public BookGenre Genre { get; set; }

            public int OriginalPublisherId { get; set; }

            public string OriginalPublisher { get; set; }

            public string Synopsis { get; set; }

            public int YearFirst { get; set; }

            public int Id { get; set; }
        }

        class ClientAuthor : IAuthor
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string ThumbNailUrl { get; set; }

            public int YearOfBirth { get; set; }

            public int? YearOfDeath { get; set; }

            public string Bio { get; set; }
        }
    }
}