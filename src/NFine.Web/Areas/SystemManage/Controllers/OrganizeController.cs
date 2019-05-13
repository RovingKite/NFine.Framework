﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using NFine.Web.Controllers;
using NFine.Web.Attributes;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class OrganizeController : BaseController
    {
        private readonly OrganizeService _organizeService;
        public OrganizeController(OrganizeService organizeService)
        {
            _organizeService = organizeService;
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
        [PermissionCheck("SystemManage_Organize_Index")]
        public ActionResult GetTreeSelectJson()
        {
            var data = _organizeService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (OrganizeGridDto item in data)
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
        [PermissionCheck("SystemManage_Organize_Index")]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var data = _organizeService.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.FullName.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (OrganizeGridDto item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id.ToString();
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentId.ToString();
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_Organize_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _organizeService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Organize_Form")]
        public ActionResult SubmitForm(OrganizeInputDto organizeInputDto, string keyValue)
        {
            _organizeService.SubmitForm(organizeInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_Organize_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _organizeService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}