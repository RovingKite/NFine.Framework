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
    public class MenuButtonController : BaseController
    {
        private readonly ResourceService _resourceService;
        public MenuButtonController(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        [HttpGet]
        public IActionResult CloneButton()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetTreeGridJson(string menuId)
        {
            var data = _resourceService.GetButtonList(menuId);
            var treeList = new List<TreeGridModel>();
            foreach (ResourceGridDto item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson(menuId));
        }

        [HttpGet]
        public ActionResult GetTreeSelectJson()
        {
            var data = _resourceService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (ResourceGridDto item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        public ActionResult GetCloneButtonTreeJson()
        {
            var resourceData = _resourceService.GetList();
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
                tree.showcheck = item.ObjectType == "Button" ? true : false;
                tree.hasChildren = hasChildren;
                tree.img = item.Icon == "" ? "" : item.Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _resourceService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(ResourceInputDto resourceInputDto, string keyValue)
        {
            _resourceService.SubmitForm(resourceInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            _resourceService.DeleteForm(keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult SubmitCloneButton(string menuId, string ids)
        {
            _resourceService.SubmitCloneButton(menuId, ids);
            return Success("克隆成功。");
        }
    }
}