using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.ExampleManage.Controllers
{
    [Area("ExampleManage")]
    public class BarCodeController : BaseController
    {
        public override IActionResult Index()
        {
            return View();
        }
    }
}