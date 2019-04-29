using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NFineCore.EntityFramework.Dto.OAManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Service.OAManage;
using NFineCore.Support;
using NFineCore.Web.Attributes;
using NFineCore.Web.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace NFineCore.Web.Areas.OAManage.Controllers
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