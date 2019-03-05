using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.Service.SystemManage;
using NFineCore.Web.Controllers;
using NFineCore.Web.Attributes;

namespace NFineCore.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class PermissionController : BaseController
    {
        private readonly ResourceService _resourceService;
        private readonly PermissionService _permissionService;
        public PermissionController(ResourceService resourceService, PermissionService permissionService)
        {
            _resourceService = resourceService;
            _permissionService = permissionService;
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
        public ActionResult GetRolePermissionTree(string roleId)
        {            
            var resourceData = _resourceService.GetList();
            var permissionData = _permissionService.GetRolePermissionList(Convert.ToInt64(roleId));
            var treeList = new List<TreeViewModel>();
            foreach (ResourceGridDto item in resourceData)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = resourceData.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = permissionData.Count(t => t.ResourceId == item.Id);
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        public ActionResult GetUserPermissionTree(string userId)
        {
            var resourceData = _resourceService.GetList();
            var permissionData = _permissionService.GetUserPermissionList(Convert.ToInt64(userId));
            var treeList = new List<TreeViewModel>();
            foreach (ResourceGridDto item in resourceData)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = resourceData.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.EnCode;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = permissionData.Count(t => t.ResourceId == item.Id);
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}