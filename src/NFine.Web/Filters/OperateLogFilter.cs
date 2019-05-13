﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NFine.Core;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.Service.SystemManage;
using NFine.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFine.Web.Filters
{
    public class OperateLogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Console.WriteLine("log-after");
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            OperatorModel operatorModel = OperatorProvider.Provider.GetOperator();
            //if (operatorModel != null)
            //{
            //    OperateLogInputDto operateLogInputDto = new OperateLogInputDto();
            //    operateLogInputDto.UserId = operatorModel.Id;
            //    operateLogInputDto.UserName = operatorModel.UserName;
            //    operateLogInputDto.Method = filterContext.HttpContext.Request.Method;
            //    operateLogInputDto.OperateTime = System.DateTime.Now;
            //    operateLogInputDto.Area = filterContext.ActionDescriptor.RouteValues["area"];
            //    operateLogInputDto.Controller = filterContext.ActionDescriptor.RouteValues["controller"];
            //    operateLogInputDto.Action = filterContext.ActionDescriptor.RouteValues["action"];
            //    operateLogInputDto.Parameter = filterContext.HttpContext.Request.QueryString.ToString();
            //    operateLogInputDto.Description = "";
            //    OperateLogService loginLogService = new OperateLogService();
            //    loginLogService.SubmitForm(operateLogInputDto, null);
            //}
        }
    }
}
