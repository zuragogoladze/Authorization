using Xunit;
using Authorization.Core.Interfaces;
using Authorization.Core.Repositories;
using Authorization.DAL.Model;
using Authorization.DAL;
using System.Linq;
using Authorization.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Tests
{
    public class RepositoryTests
    {

        private const string _salt = "testsalt";

        [Fact]
        public void GetPersons_Returns_User()
        {
            // Arrange
            var dbContext = CreateDbContext();
            PrepareDbContent(dbContext);
            IUsersRepository<User> _usersRepository = new UsersRepository(dbContext);

            // Act
            var user1 = _usersRepository.GetUser("user1", Helpers.GetPasswordHash("psw1", _salt));
            var user2 = _usersRepository.GetUser("user2", Helpers.GetPasswordHash("psw2", _salt));

            // Assert
            Assert.NotNull(user1);
            Assert.NotNull(user2);
        }


        [Fact]
        public void GetPersons_Returns_Null()
        {
            // Arrange
            var dbContext = CreateDbContext();
            PrepareDbContent(dbContext);
            IUsersRepository<User> _usersRepository = new UsersRepository(dbContext);

            // Act
            var user = _usersRepository.GetUser("user3", Helpers.GetPasswordHash("psw3", _salt));

            // Assert
            Assert.Null(user);
        }

        [Fact]
        public void FindAll_Returns_All_Users()
        {
            // Arrange
            var dbContext = CreateDbContext();
            PrepareDbContent(dbContext);
            IUsersRepository<User> _usersRepository = new UsersRepository(dbContext);

            // Act
            var users = _usersRepository.FindAll().ToList();

            // Assert
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public void Create_Creates_New_User()
        {
            // Arrange
            var dbContext = CreateDbContext();
            PrepareDbContent(dbContext);
            IUsersRepository<User> _usersRepository = new UsersRepository(dbContext);

            // Act
            var newUser = new User
            {
                Id = 3,
                Username = "user3",
                Password = Helpers.GetPasswordHash("psw3", _salt),
            };
            _usersRepository.Create(newUser);
            _usersRepository.Save();
            var addedUser = _usersRepository.GetUser(newUser.Username, newUser.Password);

            // Assert
            Assert.Equal(newUser, addedUser);
        }


        private DatabaseContext CreateDbContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Users")
                .UseInternalServiceProvider(serviceProvider);
            return new DatabaseContext(builder.Options);
        }

        private void PrepareDbContent(DatabaseContext dbContext)
        {

            var user1 = new User
            {
                Id = 1,
                Username = "user1",
                Password = Helpers.GetPasswordHash("psw1", _salt),
            };

            var user2 = new User
            {
                Id = 2,
                Username = "user2",
                Password = Helpers.GetPasswordHash("psw2", _salt),
            };

            dbContext.Users.AddRange(user1, user2);
            dbContext.SaveChanges();
        }
    }
}
