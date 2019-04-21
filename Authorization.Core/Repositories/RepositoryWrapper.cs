using Authorization.DAL;
using Authorization.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EmployeeContext _employeeContext;
        private ITagsRepository _tag;

        public ITagsRepository Tags
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagsRepository(_employeeContext);
                }

                return _tag;
            }
        }

        public RepositoryWrapper(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
    }
}
