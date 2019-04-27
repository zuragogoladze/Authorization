using System;
using System.Collections.Generic;
using System.Text;

namespace Authorization.Core.Interfaces
{
    public interface IPersonsRepository<T> : IRepositoryBase<T>
    {
        T GetPerson(string username, string password);
    }
}
