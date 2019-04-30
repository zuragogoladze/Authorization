using Authorization.Core.Interfaces;
using Authorization.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Authorization.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DatabaseContext DatabaseContext { get; set; }

        public BaseRepository(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.DatabaseContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DatabaseContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.DatabaseContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.DatabaseContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.DatabaseContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.DatabaseContext.SaveChanges();
        }
    }
}
