using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.AdvancedAPIs;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.MP.AdvancedAPIs.User;
using Senparc.Weixin.MP.Entities;

namespace NFineCore.Service.WeixinManage
{
    public class WxUserService
    {
        WxOfficialRepository wxOfficialRepository = new WxOfficialRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        WxUserRepository wxUserRepository = new WxUserRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxUserGridDto> GetList(Pagination pagination, string keyword)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxUser>(p => p.AppId == appId);
            var pagingOptions = new PagingOptions<WxUser, DateTime?>(pagination.page, pagination.rows, x => x.SubscribeTime, isDescending: true);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<WxUser>(p => p.AppId == appId && (p.Nickname.Contains(keyword)));
            }
            var list = wxUserRepository.FindAll(specification, pagingOptions).ToList();
            pagination.records = pagingOptions.TotalItems;
            return Mapper.Map<List<WxUserGridDto>>(list);
        }

        public void BatchGetUserInfo()
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            string appSecret = WxOperatorProvider.Provider.GetCurrent().AppSecret;
            AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);
            var specification = new Specification<WxUser>(p => p.AppId == appId && p.SubscribeStatus == 1 && p.SynchronisedTime == null);
            List<BatchGetUserInfoData> batchGetUserInfoDataList = new List<BatchGetUserInfoData>();
            List<WxUser> wxUserList = wxUserRepository.FindAll(specification).ToList();
            if (wxUserList.Count > 0)
            {
                foreach (WxUser wxuser in wxUserList)
                {
                    int index = wxUserList.IndexOf(wxuser);
                    if (index > 100)
                    {
                        break;
                    }
                    BatchGetUserInfoData batchGetUserInfoData = new BatchGetUserInfoData();
                    batchGetUserInfoData.openid = wxuser.OpenId;
                    batchGetUserInfoData.lang = "zh_CN";
                    batchGetUserInfoData.LangEnum = 0;
                    batchGetUserInfoDataList.Add(batchGetUserInfoData);
                }
                BatchGetUserInfoJsonResult batchGetUserInfoJsonResult =UserApi.BatchGetUserInfo(accessTokenResult.access_token, batchGetUserInfoDataList);
                if (batchGetUserInfoJsonResult.ErrorCodeValue == 0)
                {
                    if (batchGetUserInfoJsonResult.user_info_list.Count > 0)
                    {
                        foreach (UserInfoJson userInfoJson in batchGetUserInfoJsonResult.user_info_list)
                        {
                            var specification2 = new Specification<WxUser>(p => p.AppId == appId && p.OpenId == userInfoJson.openid);
                            WxUser wxUser = wxUserRepository.Find(specification2);
                            wxUser.Nickname = userInfoJson.nickname;
                            wxUser.Sex = userInfoJson.sex;
                            wxUser.HeadImgUrl = userInfoJson.headimgurl;
                            wxUser.Country = userInfoJson.country;
                            wxUser.Province = userInfoJson.province;
                            wxUser.City = userInfoJson.city;
                            wxUser.Language = userInfoJson.language;
                            wxUser.UnionId = userInfoJson.unionid;
                            wxUser.Remark = userInfoJson.remark;
                            wxUser.GroupId = userInfoJson.groupid;
                            wxUser.SynchronisedTime = System.DateTime.Now;
                            wxUserRepository.Update(wxUser);
                        }
                    }
                }
            }            
        }

        public void Subscribe(string toUserName, string fromUserName, DateTime subscribeTime)
        {
            var wxOfficialSpecification = new Specification<WxOfficial>(p => p.Account == toUserName);
            WxOfficial wxOfficial = wxOfficialRepository.Find(wxOfficialSpecification);

            var wxUserSpecification = new Specification<WxUser>(p => p.AppId == wxOfficial.AppId && p.OpenId == fromUserName);
            WxUser wxUser = wxUserRepository.Find(wxUserSpecification);
            if (wxUser == null)
            {
                wxUser = new WxUser();
                wxUser.Id = IdWorkerHelper.GenId64();
                wxUser.AppId = wxOfficial.AppId;
                wxUser.OpenId = fromUserName;
                wxUser.SubscribeTime = subscribeTime;
                wxUser.SubscribeStatus = 1;
                wxUserRepository.Add(wxUser);
            }
            else
            {
                wxUser.SubscribeStatus = 1;
                wxUser.SubscribeTime = subscribeTime;
                wxUserRepository.Update(wxUser);
            }
        }

        //public void Unsubscribe(string appId, string openId, DateTime subscribeTime)
        //{
        //    var specification = new Specification<WxUser>(p => p.AppId == appId && p.OpenId == openId);
        //    WxUser wxUser = wxUserRepository.Find(specification);
        //    if (wxUser != null)
        //    {
        //        wxUser.SubscribeStatus = 0;
        //        wxUser.SubscribeTime = subscribeTime;
        //        wxUserRepository.Update(wxUser);
        //    }
        //}
        public void Unsubscribe(string toUserName, string fromUserName, DateTime createTime)
        {
            var wxOfficialSpecification = new Specification<WxOfficial>(p => p.Account == toUserName);
            WxOfficial wxOfficial = wxOfficialRepository.Find(wxOfficialSpecification);

            var wxUserSpecification = new Specification<WxUser>(p => p.AppId == wxOfficial.AppId && p.OpenId == fromUserName);
            WxUser wxUser = wxUserRepository.Find(wxUserSpecification);
            if (wxUser != null)
            {
                wxUser.SubscribeStatus = 0;
                wxUser.SubscribeTime = createTime;
                wxUserRepository.Update(wxUser);
            }
        }
    }
}
