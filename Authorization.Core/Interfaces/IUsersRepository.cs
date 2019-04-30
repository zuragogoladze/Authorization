namespace Authorization.Core.Interfaces
{
    public interface IUsersRepository<T> : IBaseRepository<T>
    {
        T GetUser(string username, string password);
    }
}
