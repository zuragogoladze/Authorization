using Authorization.Core.Interfaces;
using Authorization.DAL;
using Authorization.DAL.Model;
using Repository;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Authorization.Core.Repositories
{
    public class PersonsRepository : RepositoryBase<Person>, IPersonsRepository<Person>
    {
        public PersonsRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
        }

        public Person GetPerson(string username, string password)
        {
            return EmployeeContext.Persons.FirstOrDefault(p => p.Username == username && p.Password == password);
        }
    }
}
