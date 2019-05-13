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
    public class ScheduleController : BaseController
    {
        private readonly IResFileService _resFileService;
        public ScheduleController(IResFileService resFileService)
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
    }
}