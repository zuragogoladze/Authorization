using Authorization.Core.Interfaces;
using Authorization.DAL;
using Authorization.DAL.Model;
using System.Linq;

namespace Authorization.Core.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository<User>
    {
        public UsersRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public User GetUser(string username, string password)
        {
            return DatabaseContext.Users.FirstOrDefault(p => p.Username == username && p.Password == password);
        }
    }
}
