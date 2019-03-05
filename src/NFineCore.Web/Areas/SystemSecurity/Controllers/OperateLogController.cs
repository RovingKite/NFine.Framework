﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Web.Controllers;
using SharpRepository.Repository;
using NFineCore.Web.Attributes;
using Newtonsoft.Json;

namespace NFineCore.Web.Areas.SystemSecurity.Controllers
{
    [Area("SystemSecurity")]
    public class OperateLogController : BaseController
    {
        private readonly OperateLogService _operateLogService;
        public OperateLogController(OperateLogService operateLogService)
        {
            _operateLogService = operateLogService;
        }

        [HttpGet]
        [PermissionCheck("SystemManage_OperateLog_Index")]
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
        [PermissionCheck("SystemManage_OperateLog_Index")]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _operateLogService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }
    }
}