using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;

namespace NFineCore.Core
{
    public static class StaticHttpContext
    {
        private static IHttpContextAccessor _contextAccessor;


        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;


        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
