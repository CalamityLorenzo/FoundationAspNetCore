using System;
using BooksCatalogueDb;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using BooksCatalogueDb.Books;
using BooksCatalogueDb.Application;

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
            Func<DbContextOptions> funMeBba = () =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<BooksCatalogueContext>();
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BooksCatalogue;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                var cFactory = new LoggerFactory();
                cFactory.AddProvider(new ConsoleLoggerProvider());

                optionsBuilder.UseLoggerFactory(cFactory);
                return optionsBuilder.Options;
            };

            BookCatalogue bc = new BookCatalogue();
            var books = bc.GetBooks();


            books.ToList().ForEach(o => Console.WriteLine(o.Genre.ToString()));

        }
    }
}