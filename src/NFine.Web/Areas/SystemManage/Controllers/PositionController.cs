﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.Service.SystemManage;
using NFine.Web.Controllers;
using NFine.Web.Attributes;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class PositionController : BaseController
    {
        private readonly PositionService _positionService;
        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }
        [PermissionCheck]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Form()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        [PermissionCheck("SystemManage_Position_Index")]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _positionService.GetList(keyword);
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Position_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _positionService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Position_Form")]
        public ActionResult SubmitForm(PositionInputDto positionInputDto, string keyValue)
        {
            _positionService.SubmitForm(positionInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Position_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _positionService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}