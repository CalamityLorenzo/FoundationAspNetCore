using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb.Application
{
    public class BooksDatabaseApp : IDisposable
    {

        DbContext ctx;

        public BooksDatabaseApp()
        {
            // Returns default value
            //This should be the norm
            if (this.ctx == null)
            {
                this.ctx = DatabaseConfig.GetContext();
            }
            this.Authors = new AuthorsCatalogue(ctx);
            this.Books = new BooksCatalogue(ctx);
            this.Publishers = new PublishersCatalogue(ctx);

        }
        // Can thqis be done ina dll agnostic manner vis a vis DbType + DbconnectionString
        //public BooksDatabaseApp(IDbType dbType)
        //{
        //    var ctx = DatabaseConfig.ConnectionFactory(dbType);
            
        //}


        public AuthorsCatalogue Authors {get;}
        public BooksCatalogue Books { get; }
        public PublishersCatalogue Publishers { get; }

        

        public void Dispose()
        {
            if(this.ctx != null)
            {
                this.ctx.Dispose();
                this.ctx = null;
            }
        }
    }
}
