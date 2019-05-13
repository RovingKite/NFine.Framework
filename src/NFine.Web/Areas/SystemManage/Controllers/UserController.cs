using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using NFine.Web.Controllers;
using SharpRepository.Repository;
using NFine.Web.Attributes;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class UserController : BaseController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [PermissionCheck]
        public override IActionResult Index()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Form()
        {
            return View();
        }
        [PermissionCheck]
        public override IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        [PermissionCheck("SystemManage_User_Index")]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = _userService.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [PermissionCheck("SystemManage_User_Form")]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _userService.GetForm(keyValue);
            if (data.UserRoles.Count > 0)
            {
                foreach (UserRole ur in data.UserRoles)
                {
                    data.RoleIds += ur.Role.Id + ",";
                    data.RoleNames += ur.Role.FullName + ",";
                }
                data.RoleIds = data.RoleIds.TrimEnd(',');
                data.RoleNames = data.RoleNames.TrimEnd(',');
            }
            return Content(data.ToJson());
        }

        [HttpPost]
        [PermissionCheck("SystemManage_User_Form")]
        public ActionResult SubmitForm(UserInputDto userInputDto,string[] roleIds, string keyValue)
        {
            _userService.SubmitForm(userInputDto, roleIds, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [PermissionCheck("SystemManage_User_Delete")]
        public ActionResult DeleteForm(string keyValue)
        {
            _userService.DeleteForm(keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        public ActionResult DisabledForm(string keyValue)
        {
            _userService.DisabledForm(keyValue);
            return Success("账户禁用成功。");
        }

        [HttpPost]
        public ActionResult EnabledForm(string keyValue)
        {
            _userService.EnabledForm(keyValue);
            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitResetPassword(string password, string keyValue)
        {
            _userService.SubmitResetPassword(password, keyValue);
            return Success("重置密码成功。");
        }

        [HttpGet]
        public ActionResult VaildUserNameExists(string username)
        {
            User user = _userService.VaildUserNameExists(username);
            if(user != null)
                return Error("用户名“" + username + "”已存在，请重新输入用户名。");
            else
                return Success("用户名不存在，可以使用。");
        }
    }
}