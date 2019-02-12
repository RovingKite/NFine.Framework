using AutoMapper;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using NFineCore.Support;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFineCore.Service.WeixinManage
{
    public class WxOfficialService
    {
        WxOfficialRepository wxOfficialRepository = new WxOfficialRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxOfficialGridDto> GetList(string keyword)
        {
            OperatorModel operatorModel = OperatorProvider.Provider.GetCurrent();
            var specification = new Specification<WxOfficial>(p => p.CreatorUserId == operatorModel.Id);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<WxOfficial>(p => p.Account.Contains(keyword) || p.Name.Contains(keyword));
            }
            var sortingOtopns = new SortingOptions<WxOfficial, DateTime?>(x => x.CreationTime, isDescending: false);
            var list = wxOfficialRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<WxOfficialGridDto>>(list);
        }

        public WxOfficialOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxOfficialOutputDto wxOfficialOutputDto = new WxOfficialOutputDto();
            WxOfficial wxOfficial = wxOfficialRepository.Get(id);
            AutoMapper.Mapper.Map<WxOfficial, WxOfficialOutputDto>(wxOfficial, wxOfficialOutputDto);
            return wxOfficialOutputDto;
        }
        public WxOfficial GetEntityByAppId(string appId)
        {
            var specification = new Specification<WxOfficial>(p => p.AppId == appId);
            WxOfficial wxOfficial = wxOfficialRepository.Find(specification);
            return wxOfficial;
        }

        public void SubmitForm(WxOfficialInputDto wxOfficialInputDto, string keyValue)
        {
            WxOfficial wxOfficial = new WxOfficial();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                wxOfficial = wxOfficialRepository.Get(id);
                AutoMapper.Mapper.Map<WxOfficialInputDto, WxOfficial>(wxOfficialInputDto, wxOfficial);
                wxOfficial.LastModificationTime = DateTime.Now;
                wxOfficialRepository.Update(wxOfficial);
            }
            else
            {
                AutoMapper.Mapper.Map<WxOfficialInputDto, WxOfficial>(wxOfficialInputDto, wxOfficial);
                wxOfficial.Id = IdWorkerHelper.GenId64();
                wxOfficial.DeletedMark = false;
                wxOfficial.CreationTime = DateTime.Now;
                wxOfficial.CreatorUserId = 1;
                wxOfficialRepository.Add(wxOfficial);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxOfficial wxOfficial = wxOfficialRepository.Get(id);
            wxOfficial.DeletedMark = true;
            wxOfficial.DeletionTime = DateTime.Now;
            wxOfficialRepository.Update(wxOfficial);
        }
    }
}
