using Cart.Business.interfaces;
using Cart.Business.Models;
using Cart.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()  
    {
        protected readonly CartDbContext _Db;
        protected readonly DbSet<TEntity> _DbSet;

        protected Repository(CartDbContext db)
        {
            _Db = db;
            _DbSet = db.Set<TEntity>(); 
        }

        public virtual async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> expression)
        {
            return await _DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _DbSet.FindAsync(id); 
        }

        public virtual async Task Add(TEntity entity)
        {
            _DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteById(Guid id)
        {
            var entity = new TEntity { Id = id };
            _DbSet.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _DbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            _Db?.Dispose();  
        }

        public async Task<int> SaveChanges()
        {
            return await _Db.SaveChangesAsync();
        }

        
    }

}
