using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Authorization.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
