using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using NFine.Web.Controllers;
using SharpRepository.Repository;
using NFine.Web.Attributes;
using NFine.Service.SystemSecurity;

namespace NFine.Web.Areas.SystemSecurity.Controllers
{
    [Area("SystemSecurity")]
    public class LoginLogController : BaseController
    {
        private readonly LoginLogService _loginLogService;
        public LoginLogController(LoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }

        [HttpGet]
        [PermissionCheck("SystemSecurity_LoginLog_Index")]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        [PermissionCheck("SystemSecurity_LoginLog_Index")]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _loginLogService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}