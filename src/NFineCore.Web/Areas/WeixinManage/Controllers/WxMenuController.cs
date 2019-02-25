using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.Service.WeixinManage;
using NFineCore.Web.Controllers;

namespace NFineCore.Web.Areas.WeixinManage.Controllers
{
    [Area("WeixinManage")]
    public class WxMenuController : BaseController
    {
        WxMenuService wxMenuService = new WxMenuService();
        [HttpGet]
        public ActionResult GetFormJson()
        {
            var data = wxMenuService.GetForm();
            return Content(data.ToJson());
        }

        public ActionResult SubmitForm(string menuData)
        {
            var wxJsonResult = wxMenuService.SubmitForm(menuData);
            if (wxJsonResult.ErrorCodeValue == 0)
            {
                return Success("操作成功。");
            }
            else
            {
                return Error("错误码："+wxJsonResult.ErrorCodeValue+ "；</br>" +
                             "错误名称："+wxJsonResult.errcode + "；</br>" +
                             "错误信息：" +wxJsonResult.errmsg + "；");
            }
        }
    }
}