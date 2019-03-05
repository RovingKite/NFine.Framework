using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Web.Controllers;
using NFineCore.Web.Attributes;

namespace NFineCore.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class AreaController : BaseController
    {
        private readonly AreaService _areaService;
        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
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
        [PermissionCheck("SystemManage_Area_Index")]
        public ActionResult GetTreeSelectJson()
        {
            var data = _areaService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (AreaGridDto item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }


        [HttpGet]
        [PermissionCheck("SystemManage_Area_Index")]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var data = _areaService.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.FullName.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (AreaGridDto item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id.ToString();
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentId.ToString();
                treeModel.expanded = false;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Area_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _areaService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Area_Form")]
        public ActionResult SubmitForm(AreaInputDto areaInputDto, string keyValue)
        {
            _areaService.SubmitForm(areaInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Area_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _areaService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}