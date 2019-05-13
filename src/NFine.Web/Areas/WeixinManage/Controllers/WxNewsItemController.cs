using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.WeixinManage;
using NFine.Service.WeixinManage;
using NFine.Web.Controllers;

namespace NFine.Web.Areas.WeixinManage.Controllers
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