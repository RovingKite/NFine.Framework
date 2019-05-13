using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NFine.Support;
using NFine.EntityFramework.Dto.WeixinManage;
using NFine.EntityFramework.Entity.WeixinManage;
using NFine.Repository.SystemManage;
using NFine.Repository.WeixinManage;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NFine.Core;

namespace NFine.Service.WeixinManage
{
    public class WxMenuService
    {
        WxMenuRepository wxMenuRepository = new WxMenuRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        
        public WxMenu GetForm()
        {
            string appId = OperatorProvider.Provider.GetOperator().WxAccountModel.AppId;
            var specification = new Specification<WxMenu>(obj => obj.AppId == appId);
            WxMenu wxMenu = wxMenuRepository.Find(specification);
            return wxMenu;
        }

        public WxJsonResult SubmitForm(string menuData)
        {
            string appId = OperatorProvider.Provider.GetOperator().WxAccountModel.AppId;
            var specification = new Specification<WxMenu>(obj => obj.AppId == appId);
            WxMenu wxMenu = wxMenuRepository.Find(specification);
            if (wxMenu == null)
            {
                wxMenu = new WxMenu();
                wxMenu.Id = IdWorkerHelper.GenId64();
                wxMenu.AppId = appId;
                wxMenu.MenuData = menuData;
                wxMenu.CreationTime = System.DateTime.Now;
                wxMenu.DeletedMark = false;
                wxMenuRepository.Add(wxMenu);
            }
            else
            {
                wxMenu.MenuData = menuData;
                wxMenu.LastModificationTime = System.DateTime.Now;
                wxMenuRepository.Update(wxMenu);
            }
            JObject jo = (JObject)JsonConvert.DeserializeObject(menuData);
            JObject menu = (JObject)jo["menu"];
            JArray button = (JArray)menu["button"];
            Debug.WriteLine(menu.ToString());
            AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);
            
            WxJsonResult wxJsonResult = CommonApi.CreateMenu(accessTokenResult.access_token, menu);
            return wxJsonResult;
        }
    }
}
