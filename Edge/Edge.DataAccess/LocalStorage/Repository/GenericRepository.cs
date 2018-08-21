using Edge.DataAccess.LocalStorage.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge.DataAccess.LocalStorage.Repository
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }
        
        public virtual List<T> GetAll()
        {

            List<T> collection = _entities.Set<T>().ToList();
            return collection;
        }

        public List<T> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            List<T> collection = _entities.Set<T>().Where(predicate).ToList();
            return collection;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

    }
}
