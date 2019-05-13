using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Dto.WeixinManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using NFine.Service.WeixinManage;
using NFine.Web.Controllers;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.Media;

namespace NFine.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxImageController : BaseController
    {
        WxImageService wxImageService = new WxImageService();

        private readonly IHostingEnvironment _hostingEnvironment;

        public WxImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override IActionResult Upload()
        {
            return View();
        }
        public IActionResult Grid()
        {
            return View();
        }
        public IActionResult Choose()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = wxImageService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                start = pagination.start,
                end = pagination.end
            };
            return Content(data.ToJson());
        }

        //[HttpGet]
        //public ActionResult GetImageMaterialList()
        //{
        //    string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
        //    GetMediaCountResultJson getMediaCountResultJson = MediaApi.GetMediaCount(appId);
        //    wxImageService.SyncImageMaterial();
        //    return Content(getMediaCountResultJson.ToJson());
        //}

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wxImageService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(WxImageInputDto wxImageInputDto, string keyValue)
        {
            wxImageService.SubmitForm(wxImageInputDto, keyValue);
            return Success("操作成功。");
        }


        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            wxImageService.DeleteForm(keyValue);
            return Success("操作成功。");
        }

        //[HttpPost]
        //public ActionResult UploadForm(string keyValue)
        //{
        //    var webRootPath = _hostingEnvironment.WebRootPath;
        //    wxImageService.UploadForm(keyValue, webRootPath);
        //    return Success("操作成功。");
        //}

        [HttpPost]
        public ActionResult UploadForeverImage(string keyValue)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var uploadForeverMediaResult = wxImageService.UploadForeverImage(keyValue, webRootPath);
            if (uploadForeverMediaResult.errcode == 0)
            {
                return Success("操作成功。");
            }
            else
            {
                return Error(uploadForeverMediaResult.errmsg);
            }
        }

        [HttpPost]
        public ActionResult DownloadForm(string keyValue)
        {
            //var webRootPath = _hostingEnvironment.WebRootPath;
            //wxImageService.UploadForm(keyValue, webRootPath);
            return Success("操作成功。");
        }
    }
}