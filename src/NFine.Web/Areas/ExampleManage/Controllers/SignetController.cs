using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Web.Controllers;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    [Area("ExampleManage")]
    public class SignetController : BaseController
    {
        public override IActionResult Index()
        {
            return View();
        }
    }
}