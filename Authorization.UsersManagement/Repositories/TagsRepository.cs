using Authorization.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Authorization.Core.Interfaces;
using Authorization.DAL;

namespace Repository
{
    public class TagsRepository : RepositoryBase<Tags>, ITagsRepository
    {
        public TagsRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
        }
    }
}
