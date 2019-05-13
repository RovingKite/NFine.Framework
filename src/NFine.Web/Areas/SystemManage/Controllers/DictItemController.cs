using System;
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
    public class DictItemController : BaseController
    {
        private readonly DictService _dictService;
        private readonly DictItemService _dictItemService;
        public DictItemController(DictService dictService, DictItemService dictItemService)
        {
            _dictService = dictService;
            _dictItemService = dictItemService;
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
        public ActionResult GetGridJson(long dictId, string keyword)
        {
            var data = _dictItemService.GetList(dictId, keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _dictItemService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(DictItemInputDto dictItemInputDto, string keyValue)
        {
            throw new Exception("一个未知错误");
            _dictItemService.SubmitForm(dictItemInputDto, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            _dictItemService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
        [HttpGet]
        public ActionResult GetSelectJson(string enCode)
        {
            var data = _dictService.GetDictItemList(enCode);
            List<object> list = new List<object>();
            foreach (DictItemGridDto item in data)
            {
                list.Add(new { id = item.ItemCode, text = item.ItemName });
            }
            return Content(list.ToJson());
        }
    }
}