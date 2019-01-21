using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NFineCore.WebApi.Controllers
{
     [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World!");
        }

        public IActionResult Get()
        {
            return Json("请求成功！");
        }
    }
}