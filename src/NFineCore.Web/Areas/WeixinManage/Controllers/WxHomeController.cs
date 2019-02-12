using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Support;
using Senparc.Weixin.MP.Containers;
using SharpRepository.Repository;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxHomeController : Controller
    {
        WxOfficialService wxOfficialService = new WxOfficialService();

        [HttpGet]
        public ActionResult Index(string keyValue)
        {
            WxOfficialOutputDto wxOfficialOutputDto = wxOfficialService.GetForm(keyValue);
            WxOperatorModel wxOperatorModel = new WxOperatorModel();
            wxOperatorModel.AppId = wxOfficialOutputDto.AppId;
            wxOperatorModel.Name = wxOfficialOutputDto.Name;
            wxOperatorModel.AppSecret = wxOfficialOutputDto.AppSecret;
            wxOperatorModel.AppType = wxOfficialOutputDto.AppType;
            WxOperatorProvider.Provider.AddCurrent(wxOperatorModel);
            var aaa = WxOperatorProvider.Provider.GetCurrent();
            AccessTokenContainer.Register(wxOfficialOutputDto.AppId, wxOfficialOutputDto.AppSecret);

            ViewData["AppName"] = wxOfficialOutputDto.Name;
            return View();
        }

        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
    }
}