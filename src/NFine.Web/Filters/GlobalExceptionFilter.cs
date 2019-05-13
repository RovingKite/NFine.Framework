using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFine.Web.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //throw new NotImplementedException();
            context.Result = new ContentResult
            {
                Content = context.Exception.Message,
                StatusCode = StatusCodes.Status500InternalServerError,
                ContentType = "application/json;charset=utf-8"
                //ContentType = "text/html;charset=utf-8"
            };
            context.ExceptionHandled = true;
        }
    }
}
