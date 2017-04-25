using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksCatalogueDb
{
    public static class DatabaseConfig
    {
        private static DbContextOptions ReasonableDefault()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BooksCatalogue;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return builder.Options;

        }

        private static Func<DbContextOptions> DbContextOptionsBox = ReasonableDefault;
 
        public static void SetDbOptions(Func<DbContextOptions> dbContext) => DbContextOptionsBox = dbContext;

        internal static BooksCatalogueContext GetContext() => new BooksCatalogueContext(DbContextOptionsBox());
    }
}
