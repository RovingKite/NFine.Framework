using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Web.Controllers;
using SharpRepository.Repository;
using NFineCore.Web.Attributes;
using Newtonsoft.Json;

namespace NFineCore.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class AttachController : BaseController
    {
        private readonly AttachService _attachService;
        public AttachController(AttachService attachService)
        {
            _attachService = attachService;
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Attach_Index")]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Upload()
        {
            return View();
        }
        [HttpGet]
        [PermissionCheck("SystemManage_Attach_Index")]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _attachService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }
    }
}