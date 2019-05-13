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