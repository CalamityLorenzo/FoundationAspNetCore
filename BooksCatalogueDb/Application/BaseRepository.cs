using BooksCatalogueDb.BookInterface;
using BooksCatalogueDb.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BooksCatalogueDb.Application
{
    public abstract class BaseRepository<EntityDB, IApp> where EntityDB : BaseEntity
                                         where IApp : IBaseEntity
    {
        internal DbContext ctx;
        internal DbSet<EntityDB> DbEnties;
        internal virtual Func<EntityDB, IApp> MapFromDb { get; }
        internal virtual Func<IApp, EntityDB> MapToDb { get; }
        internal Func<IEnumerable<IApp>, IEnumerable<EntityDB>> MapAllToDb => (appEntities) => appEntities.Select(MapToDb);
        internal Func<IQueryable<EntityDB>, IEnumerable<IApp>> MapAllFromDb => (dbEntities) => dbEntities.Select(MapFromDb);
        internal BaseRepository(DbContext ctx)
        {
            this.ctx = ctx;
            this.DbEnties = ctx.Set<EntityDB>();
        }

        public BaseRepository()
        {
            ctx = DatabaseConfig.GetContext();
            this.DbEnties = ctx.Set<EntityDB>();
        }

        public IApp Get(int Id)
        {
            return MapFromDb(this.DbEnties.Single(o => o.Id == Id));
        }

        public void Add(IApp NewEntity)
        {
            DbEnties.Add(MapToDb(NewEntity));
            ctx.SaveChanges();
        }

        public async Task AddAsync(IApp NewEntity)
        {
            var item = MapToDb(NewEntity);
            DbEnties.Add(item);
            await ctx.SaveChangesAsync();
        }

        public async Task Update(IApp ExistingEntity)
        {
            var dbVersion = MapToDb(ExistingEntity);
            DbEnties.Update(dbVersion);
            await ctx.SaveChangesAsync();
        }
    }
}
