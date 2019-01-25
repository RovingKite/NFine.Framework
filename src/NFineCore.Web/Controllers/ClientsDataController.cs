using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Service.SystemManage;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NFineCore.Web.Controllers
{
    public class ClientsDataController : Controller
    {
        private readonly PermissionService _permissionService;
        private readonly DictItemService _dictItemService;
        private readonly DictService _dictService;
        private readonly OrganizeService _organizeService;
        private readonly RoleService _roleService;
        private readonly UserService _userService;
        private readonly ResourceService _resourceService;
        private readonly PositionService _positionService;
        public ClientsDataController(
            PermissionService permissionService, 
            DictItemService dictItemService, 
            DictService dictService, 
            OrganizeService organizeService,
            RoleService roleService,
            UserService userService,
            ResourceService resourceService,
            PositionService positionService)
        {
            _permissionService = permissionService;
            _dictItemService = dictItemService;
            _dictService = dictService;
            _organizeService = organizeService;
            _roleService = roleService;
            _userService = userService;
            _resourceService = resourceService;
            _positionService = positionService;
        }
        [HttpGet]
        public IActionResult GetClientsDataJson()
        {
            OperatorModel operatorModel = OperatorProvider.Provider.GetCurrent();
            var permissions = _permissionService.GetPermsResList(Convert.ToInt64(operatorModel.Id));
            var data = new
            {
                dataItems = this.GetDictItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                position = this.GetPositionList(),
                currentUser = this.GetUserForm(operatorModel.Id),
                authorizeMenu = this.GetMenuList(permissions),
                authorizeButton = this.GetMenuButtonList(permissions),
                wxMenu = this.GetWxMenuList()
            };
            return Content(data.ToJson());
        }

        private object GetDictItemList()
        {
            var itemdata = _dictItemService.GetList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            foreach (var item in new DictService().GetList())
            {
                var dataItemList = itemdata.FindAll(t => t.DictId.Equals(item.Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemCode, itemList.ItemName);
                }
                dictionaryItem.Add(item.EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }

        private object GetOrganizeList()
        {
            var data = _organizeService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (OrganizeGridDto item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id.ToString(), fieldItem);
            }
            return dictionary;
        }

        private object GetRoleList()
        {
            var data = _roleService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleGridDto item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        private object GetPositionList()
        {
            var data = _positionService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (PositionGridDto item in data)
            {
                var fieldItem = new
                {
                    encode = item.EnCode,
                    fullname = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
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