using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NFine.EntityFramework.Dto.OAManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.OAManage;
using NFine.Support;
using NFine.Web.Attributes;
using NFine.Web.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Web.Areas.OAManage.Controllers
{
    [Area("OAManage")]
    public class ResFileController : BaseController
    {
        private readonly IResFileService _resFileService;
        public ResFileController(IResFileService resFileService)
        {
            _resFileService = resFileService;
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [PermissionCheck("OAManage_ResFile_Index")]
        public override IActionResult Upload()
        {
            return View();
        }
        [PermissionCheck("OAManage_ResFile_Index")]
        public IActionResult MultiUpload()
        {
            return View();
        }
        [PermissionCheck("OAManage_ResFile_Index")]
        public IActionResult NewFolder()
        {
            return View();
        }
        [PermissionCheck("OAManage_ResFile_Index")]
        public IActionResult SubmitNewFolder(string folderName)
        {
            _resFileService.NewFolder(folderName);
            return Success("操作成功。");
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _resFileService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetTreeJson()
        {
            var treeList = new List<TreeViewModel>();
            TreeViewModel tree1 = new TreeViewModel();
            tree1.id = "1";
            tree1.text = "所有文件";
            tree1.value = "All";
            tree1.parentId = "0";
            tree1.isexpand = true;
            tree1.complete = true;
            tree1.hasChildren = false;
            treeList.Add(tree1);

            TreeViewModel tree2 = new TreeViewModel();
            tree2.id = "2";
            tree2.text = "文档";
            tree2.value = "Document";
            tree2.parentId = "0";
            tree2.isexpand = true;
            tree2.complete = true;
            tree2.hasChildren = false;
            treeList.Add(tree2);

            TreeViewModel tree3 = new TreeViewModel();
            tree3.id = "3";
            tree3.text = "图片";
            tree3.value = "Image";
            tree3.parentId = "0";
            tree3.isexpand = true;
            tree3.complete = true;
            tree3.hasChildren = false;
            treeList.Add(tree3);

            TreeViewModel tree4 = new TreeViewModel();
            tree4.id = "4";
            tree4.text = "回收站";
            tree4.value = "Recycle";
            tree4.parentId = "0";
            tree4.isexpand = true;
            tree4.complete = true;
            tree4.hasChildren = false;
            treeList.Add(tree4);
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetFolderTreeJson()
        {
            var data = _resFileService.GetFolderList();
            var treeList = new List<TreeViewModel>();
            foreach (ResFileGridDto item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FileName;
                tree.value = item.Id;
                tree.parentId = item.ParentId.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = false;
                tree.checkstate = 0;
                tree.hasChildren = hasChildren;
                tree.img = "";
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetGridJson(string keyword)
        {
            var data = _resFileService.GetList(keyword);
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetRootFiles()
        {
            var data = _resFileService.GetRootFiles();
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetDocumentFiles()
        {
            var data = _resFileService.GetDocumentFiles();
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetImageFiles()
        {
            var data = _resFileService.GetImageFiles();
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }


        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetRecycleFiles()
        {
            var data = _resFileService.GetRecycleFiles();
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }
        [HttpGet]
        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult GetChildrenFiles(string parentId)
        {
            var data = _resFileService.GetChildrenFiles(parentId);
            Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
            return Content(data.ToJson());
        }

        //[HttpGet]
        //[PermissionCheck("OAManage_ResFile_Index")]
        //public ActionResult GetGridJson(string fileType, string keyword)
        //{
        //    var data = _resFileService.GetList(fileType, keyword);
        //    Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
        //    return Content(data.ToJson());
        //}

        //[HttpGet]
        //[PermissionCheck("OAManage_ResFile_Index")]
        //public ActionResult GetGridJsonByParentId(string parentId, string keyword)
        //{
        //    var data = _resFileService.GetListByParentId(parentId, keyword);
        //    Logger.Info(JsonConvert.SerializeObject(data));//此处调用日志记录函数记录日志
        //    return Content(data.ToJson());
        //}

        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            _resFileService.DeleteForm(keyValue);
            return Success("操作成功。");
        }

        [PermissionCheck("OAManage_ResFile_Index")]
        public ActionResult DeleteCompletely(string keyValue)
        {
            _resFileService.DeleteCompletely(keyValue);
            return Success("操作成功。");
        }

        public ActionResult EmptyRecycle()
        {
            _resFileService.EmptyRecycle();
            return Success("操作成功。");
        }
        public ActionResult Rename()
        {
            return View();
        }
        public ActionResult Move()
        {
            return View();
        }
        public ActionResult SubmitRename(string keyValue, string fileName)
        {
            _resFileService.Rename(keyValue, fileName);
            return Success("操作成功。");
        }
        public ActionResult RestoreForm(string keyValue)
        {
            _resFileService.Restore(keyValue);
            return Success("操作成功。");
        }
    }
}