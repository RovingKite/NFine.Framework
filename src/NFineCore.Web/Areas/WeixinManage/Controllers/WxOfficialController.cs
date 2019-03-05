using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;
using NFineCore.Web.Attributes;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxOfficialController : BaseController
    {
        WxOfficialService wxOfficialService = new WxOfficialService();

        [PermissionCheck]
        public override IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGridJson(string keyword)
        {
            var data = new
            {
                rows = wxOfficialService.GetList(keyword)
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wxOfficialService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(WxOfficialInputDto wxOfficialInputDto, string keyValue)
        {
            wxOfficialService.SubmitForm(wxOfficialInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            wxOfficialService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}