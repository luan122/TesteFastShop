using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFast.Data.Data.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(long id);
        IQueryable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(long id);
        Task<int> SaveChanges();
    }
}
