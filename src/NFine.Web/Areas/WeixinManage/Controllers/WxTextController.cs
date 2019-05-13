using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Dto.WeixinManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using NFine.Service.WeixinManage;
using NFine.Web.Controllers;

namespace NFine.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxTextController : BaseController
    {
        WxTextService wxTextService = new WxTextService();

        [HttpGet]
        public ActionResult GetGridJson(string keyword)
        {
            var data = new
            {
                rows = wxTextService.GetList(keyword)
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wxTextService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(WxTextInputDto wxTextInputDto, string keyValue)
        {
            wxTextService.SubmitForm(wxTextInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            wxTextService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}