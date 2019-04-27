using Authorization.Core.Interfaces;
using Authorization.DAL;
using Authorization.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Xunit;

namespace Authorization.Tests
{
    public class RepositoryTests
    {

        private readonly IPersonsRepository<Person> _personsRepository;

        public RepositoryTests(IPersonsRepository<Person> personsRepository)
        {
            this._personsRepository = personsRepository;
        }
        [Fact]
        public void GetPersons_Returns_Valid_User()
        {
            // Arrange
            //var dbContext = CreateDbContext();
            //PrepareDbContent(dbContext);
        }
    }
}
