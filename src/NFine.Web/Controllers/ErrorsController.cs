﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NFine.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Http404()
        {
            return View();
        }

        public IActionResult Http500()
        {
            return View();
        }
    }
}