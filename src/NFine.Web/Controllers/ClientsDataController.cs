using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Service.SystemManage;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NFine.Core;
using NFine.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace NFine.Web.Controllers
{
    public class ClientsDataController : Controller
    {
        private readonly PermissionService _permissionService;
        private readonly UserService _userService;
        private readonly ResourceService _resourceService;
        public ClientsDataController(PermissionService permissionService, UserService userService, ResourceService resourceService)
        {
            _permissionService = permissionService;
            _userService = userService;
            _resourceService = resourceService;
        }

        [HttpGet]
        public IActionResult GetClientsDataJson()
        {
            //using (var dbContext = new NFineDbContext())
            //{
            //    var admin = dbContext.Users.First(p => p.UserName == "admin");//第一次从数据库中查询Person实体tom

            //    string query = "SELECT * FROM sys_user";
            //    var conn = dbContext.Database.GetDbConnection();
            //    var aaa = conn.Query<User>(query).ToList();
            //}

            OperatorModel operatorModel = OperatorProvider.Provider.GetOperator();
            var permissions = _permissionService.GetPermsResList(Convert.ToInt64(operatorModel.Id));
            var data = new
            {
                currentUser = this.GetUserForm(operatorModel.Id.ToString()),
                authorizeMenu = this.GetMenuList(permissions),
                authorizeButton = this.GetMenuButtonList(permissions),
                //wxMenu = this.GetWxMenuList()
            };
            return Content(data.ToJson());
        }

        private object GetMenuList(List<ResourceGridDto> resources)
        {
            resources = resources.Where(a => a.ObjectType == "Menu").ToList();
            return ToMenuJson(resources, "0");
        }

        private object GetWxMenuList()
        {
            var wxMenus = _resourceService.GetWxMenuList();
            return ToMenuJson(wxMenus, "0");
        }

        private string ToMenuJson(List<ResourceGridDto> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ResourceGridDto> entitys = data.FindAll(t => t.ParentId.ToString() == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Id.ToString()) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

        private object GetMenuButtonList(List<ResourceGridDto> resources)
        {
            resources = resources.Where(a => a.ObjectType == "Button").ToList();
            var dataModuleId = resources.Distinct(new ExtList<ResourceGridDto>("ParentId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ResourceGridDto item in dataModuleId)
            {
                var buttonList = resources.Where(t => t.ParentId.Equals(item.ParentId));
                dictionary.Add(item.ParentId, buttonList);
            }
            return dictionary;
        }

        private object GetUserForm(string keyValue)
        {
            var data = _userService.GetForm(keyValue);
            return data;
        }
    }
}