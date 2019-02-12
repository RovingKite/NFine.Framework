using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFineCore.Service.WeixinManage
{
    public class WxTextService
    {
        WxTextRepository wxTextRepository = new WxTextRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxTextGridDto> GetList(string keyword)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxText>(p => p.DeletedMark == false && p.AppId == appId);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<WxText>(p => p.DeletedMark == false && p.AppId == appId && (p.Title.Contains(keyword) || p.Content.Contains(keyword)));
            }
            var sortingOtopns = new SortingOptions<WxText, DateTime?>(x => x.CreationTime, isDescending: false);
            var list = wxTextRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<WxTextGridDto>>(list);
        }

        public WxTextOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxTextOutputDto wxTextOutputDto = new WxTextOutputDto();
            WxText wxText = wxTextRepository.Get(id);
            AutoMapper.Mapper.Map<WxText, WxTextOutputDto>(wxText, wxTextOutputDto);
            return wxTextOutputDto;
        }

        public void SubmitForm(WxTextInputDto wxTextInputDto, string keyValue)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            WxText wxText = new WxText();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);                
                wxText = wxTextRepository.Get(id);
                AutoMapper.Mapper.Map<WxTextInputDto, WxText>(wxTextInputDto, wxText);
                wxText.LastModificationTime = DateTime.Now;
                wxTextRepository.Update(wxText);
            }
            else
            {
                AutoMapper.Mapper.Map<WxTextInputDto, WxText>(wxTextInputDto, wxText);
                wxText.Id = IdWorkerHelper.GenId64();
                wxText.AppId = appId;
                wxText.DeletedMark = false;
                wxText.CreationTime = DateTime.Now;
                wxText.CreatorUserId = 1;
                wxTextRepository.Add(wxText);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxText wxText = wxTextRepository.Get(id);
            wxText.DeletedMark = true;
            wxText.DeletionTime = DateTime.Now;
            wxTextRepository.Update(wxText);
        }
    }
}
