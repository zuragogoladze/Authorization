using Authorization.DAL;
using Authorization.UsersManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EmployeeContext _employeeContext;
        private IEmployeeRepository _employee;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_employeeContext);
                }

                return _employee;
            }
        }

        public RepositoryWrapper(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
    }
}
