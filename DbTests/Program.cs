using System;
using BooksCatalogueDb;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
namespace DbTests
{
    class Program
    {
        static void Main(string[] args)
        {



            DoThings().Wait();
        }

        static async Task  DoThings()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksCatalogueContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BooksCatalogue;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var cFactory = new LoggerFactory();
            cFactory.AddProvider(new ConsoleLoggerProvider());

            optionsBuilder.UseLoggerFactory(cFactory);

            using (BooksCatalogueContext bcc = new BooksCatalogueContext(optionsBuilder.Options))
            {

               
                var bookAuthor = bcc.BookAuthors.Include(p=>p.Author).Where(o => o.BookId > 27).ToList();

                var boks = bcc.Books.Include(o=>o.Authors).ThenInclude(p=>p.Author).ToList();
               // var authors = bcc.Authors.Include(o => o.Books).ToList();
                var lastBook = boks.Last();
                var itme = lastBook.Authors.ToList();


                Console.WriteLine("***********************");
                Console.WriteLine($"{lastBook.Name}");
                Console.WriteLine("COUNT: " + itme.Count);

            }

            
        }
    }
}   