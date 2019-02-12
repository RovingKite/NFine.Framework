using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxMenuController : BaseController
    {
        WxMenuService wxMenuService = new WxMenuService();
        [HttpGet]
        public ActionResult GetFormJson()
        {
            var data = wxMenuService.GetForm();
            return Content(data.ToJson());
        }

        public ActionResult SubmitForm(string menuData)
        {
            wxMenuService.SubmitForm(menuData);
            return Success("操作成功。");
        }
    }
}