using Authorization.DAL;
using Authorization.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EmployeeContext EmployeeContext { get; set; }

        public RepositoryBase(EmployeeContext employeeContext)
        {
            this.EmployeeContext = employeeContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.EmployeeContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.EmployeeContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.EmployeeContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.EmployeeContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.EmployeeContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.EmployeeContext.SaveChanges();
        }
    }
}
