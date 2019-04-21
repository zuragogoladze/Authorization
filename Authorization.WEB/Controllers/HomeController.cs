﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authorization.Core.ViewModels;
using Authorization.WEB.Controllers.Shared;
using Authorization.Core.Interfaces;

namespace Authorization.WEB.Controllers
{
    public class HomeController : SharedController
    {
        public HomeController(IRepositoryWrapper repoWrapper) : base(repoWrapper)
        {
        }

        public IActionResult Index()
        {
            var model = _repoWrapper.Tags.FindAll();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
