using Cart.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.interfaces
{
    public interface IRepository<TEntity> :IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task DeleteById(Guid id);

        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> expression);

        Task<int> SaveChanges();
    }
    
}
