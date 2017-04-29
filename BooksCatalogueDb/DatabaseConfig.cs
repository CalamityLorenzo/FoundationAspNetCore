using BooksCatalogueDb.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb
{
    public static class DatabaseConfig
    {
        // IF you don't set the db this is chosen
        private static DbContextOptions ReasonableDefault()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BooksCatalogue;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return builder.Options;

        }
        // THe actual method that will be called. Defaults to something marginally useful
        private static Func<DbContextOptions> DbContextOptionsBox = ReasonableDefault;

        internal static BooksCatalogueContext GetContext() => new BooksCatalogueContext(DbContextOptionsBox());

        // PUblic methods to choose the internal
        // Trying to not let the dbCOntext stuff leack from the dll.
        public static void SetDbOptions(Func<DbContextOptions> dbContext) => DbContextOptionsBox = dbContext;

        public static void UseSqlServer(string connection) => SetDbOptions(() =>
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connection);
            return builder.Options;
        });

        public static void UseSQLite(string connection) => SetDbOptions(() =>
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite(connection);
            return builder.Options;
        });
        
    }
}
