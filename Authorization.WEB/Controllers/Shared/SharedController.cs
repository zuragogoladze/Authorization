using Authorization.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.WEB.Controllers.Shared
{
    [Authorize]
    public class SharedController : Controller
    {
        //protected IRepositoryWrapper _repoWrapper;

        //public SharedController(IRepositoryWrapper repoWrapper)
        //{
        //    _repoWrapper = repoWrapper;
        //}
    }
}
