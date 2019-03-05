using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.GroupMessage;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using SharpRepository.Repository.FetchStrategies;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NFineCore.EntityFramework;

namespace NFineCore.Service.WeixinManage
{
    public class WxNewsItemService
    {
        WxNewsRepository wxNewsRepository = new WxNewsRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        WxNewsItemRepository wxNewsItemRepository = new WxNewsItemRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public WxNewsItemOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            var genericFetchStrategy = new GenericFetchStrategy<WxNewsItem>().Include(p => p.Thumb);
            WxNewsItem wxNewsItem = wxNewsItemRepository.Get(id, genericFetchStrategy);
            WxNewsItemOutputDto wxNewsItemOutputDto = new WxNewsItemOutputDto();
            AutoMapper.Mapper.Map<WxNewsItem, WxNewsItemOutputDto>(wxNewsItem, wxNewsItemOutputDto);
            return wxNewsItemOutputDto;
        }
    }
}
