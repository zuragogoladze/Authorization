using Authorization.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Authorization.UsersManagement.Interfaces;
using Authorization.DAL;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
        }
    }
}
