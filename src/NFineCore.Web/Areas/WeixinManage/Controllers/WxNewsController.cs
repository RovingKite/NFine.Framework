﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxNewsController : BaseController
    {
        WxNewsService wxNewsService = new WxNewsService();

        public IActionResult Choose()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = wxNewsService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                start = pagination.start,
                end = pagination.end
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = wxNewsService.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        public ActionResult SubmitForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            wxNewsService.SubmitForm(wxNewsInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult UploadForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            wxNewsService.UploadForm(wxNewsInputDto, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult UploadForeverNews(string keyValue)
        {
            var uploadForeverMediaResult = wxNewsService.UploadForeverNews(keyValue);
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
        public ActionResult UpdateForeverNews(WxNewsInputDto wxNewsInputDto,string keyValue)
        {
            var uploadForeverMediaResult = wxNewsService.UploadForeverNews(keyValue);
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
        public ActionResult DeleteForm(string keyValue)
        {
            wxNewsService.DeleteForm(keyValue);
            return Success("操作成功。");
        }
    }
}