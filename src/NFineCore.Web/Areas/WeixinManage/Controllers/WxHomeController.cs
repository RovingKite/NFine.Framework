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
using NFineCore.Core;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Service.WeixinManage;
using NFineCore.Support;
using Senparc.Weixin.MP.Containers;
using SharpRepository.Repository;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxHomeController : Controller
    {
        WxAccountService wxAccountService = new WxAccountService();

        [HttpGet]
        public ActionResult Index(string keyValue)
        {
            WxAccountOutputDto wxAccountOutputDto = wxAccountService.GetForm(keyValue);
            OperatorModel operatorModel = OperatorProvider.Provider.GetOperator();
            if (operatorModel.WxAccountModel == null) {
                operatorModel.WxAccountModel = new WxAccountModel();
            }
            operatorModel.WxAccountModel.AppId = wxAccountOutputDto.AppId;
            operatorModel.WxAccountModel.Name = wxAccountOutputDto.Name;
            operatorModel.WxAccountModel.AppSecret = wxAccountOutputDto.AppSecret;
            operatorModel.WxAccountModel.AppType = wxAccountOutputDto.AppType;
            OperatorProvider.Provider.AddOperator(operatorModel);

            AccessTokenContainer.Register(wxAccountOutputDto.AppId, wxAccountOutputDto.AppSecret);

            ViewData["AppName"] = wxAccountOutputDto.Name;
            return View();
        }

        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
    }
}