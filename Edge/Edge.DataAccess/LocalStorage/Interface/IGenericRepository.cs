using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edge.DataAccess.LocalStorage.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
