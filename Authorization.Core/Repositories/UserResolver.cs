using Authorization.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Authorization.Core.Repositories
{
    public class UserResolver : IUserResolver
    {
        private readonly IHttpContextAccessor _context;
        public UserResolver(IHttpContextAccessor context)
        {
            _context = context;
        }

        public ClaimsPrincipal User => _context.HttpContext?.User;
    }
}
