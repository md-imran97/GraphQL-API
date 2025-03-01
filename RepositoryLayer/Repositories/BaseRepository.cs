using DataAccessLayer.Database;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;
        public BaseRepository(DbContext dataSourceContext)
        {
            _context = dataSourceContext;
            _entities = _context.Set<TEntity>();
        }
        public virtual TEntity Get(TKey id)
        {
            return _entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(TKey id)
        {
            var entity = _entities.Find(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }

    }
}
