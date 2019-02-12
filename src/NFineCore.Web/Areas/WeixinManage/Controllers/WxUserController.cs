using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxUserController : BaseController
    {
        WxUserService wxUserService = new WxUserService();

        [HttpGet]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = wxUserService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            };
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult BatchGetUserInfo()
        {
            wxUserService.BatchGetUserInfo();
            return Success("操作成功。");
        }
    }
}