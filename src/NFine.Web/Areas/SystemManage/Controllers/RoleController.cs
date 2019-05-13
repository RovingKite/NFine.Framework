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

namespace NFine.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class RoleController : BaseController
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
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
        [PermissionCheck("SystemManage_Role_Index")]
        public ActionResult GetSelectJson(string keyword)
        {
            var data = _roleService.GetList(keyword);
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Role_Index")]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _roleService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Role_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _roleService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Role_Form")]
        public ActionResult SubmitForm(RoleInputDto roleInputDto, string resourceIds, string keyValue)
        {
            string[] resourceIdsArray = { };
            if (!string.IsNullOrEmpty(resourceIds))
            {
                resourceIdsArray = resourceIds.Split(',');
            }
            _roleService.SubmitForm(roleInputDto, resourceIdsArray, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Role_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _roleService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}