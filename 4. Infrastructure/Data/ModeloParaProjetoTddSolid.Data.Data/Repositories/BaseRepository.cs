using Microsoft.EntityFrameworkCore;
using TestFast.Data.Data.Context;
using TestFast.Data.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFast.Data.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            return obj;
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            return obj;
        }

        public virtual void Remove(long id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
