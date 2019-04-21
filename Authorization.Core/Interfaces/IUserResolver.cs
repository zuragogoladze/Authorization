using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Authorization.Core.Interfaces
{
    public interface IUserResolver
    {
        ClaimsPrincipal User { get; }
    }
}
