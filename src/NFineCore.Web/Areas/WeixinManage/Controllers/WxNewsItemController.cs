using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxNewsItemController : BaseController
    {
        WxNewsItemService wxNewsItemService = new WxNewsItemService();

        public IActionResult Preview()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wxNewsItemService.GetForm(keyValue);
            return Content(data.ToJson());
        }
    }
}