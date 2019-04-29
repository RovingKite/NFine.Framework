
using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Repository.SystemManage;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using SharpRepository.Repository.Queries;

namespace NFineCore.Service.SystemManage
{
    public class DictItemService
    {
        DictItemRepository dictItemRepository = new DictItemRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<DictItemGridDto> GetList()
        {
            var list = dictItemRepository.GetAll().ToList();
            return Mapper.Map<List<DictItemGridDto>>(list);
        }

        public List<DictItemGridDto> GetList(long dictId,string keyword)
        {
            List<Specification<DictItem>> specList = new List<Specification<DictItem>>();

            var specification = new Specification<DictItem>(p => p.DeletedMark==false && p.Dict.Id == dictId);

            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<DictItem>(p => p.DeletedMark == false && p.Dict.Id == dictId && (p.ItemCode.Contains(keyword) || p.ItemName.Contains(keyword)));
            }
            var sortingOtopns = new SortingOptions<DictItem, int?>(x => x.SortCode, isDescending: false);
            var list = dictItemRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<DictItemGridDto>>(list);
        }

        public DictItemOutputDto GetForm(string keyValue)
        {
            long id = Convert.ToInt64(keyValue);
            DictItemOutputDto dictItemOutputDto = new DictItemOutputDto();
            DictItem dict = dictItemRepository.Get(id);
            AutoMapper.Mapper.Map<DictItem, DictItemOutputDto>(dict, dictItemOutputDto);
            return dictItemOutputDto;
        }

        public void SubmitForm(DictItemInputDto dictItemInputDto, string keyValue)
        {
            DictItem dictItem = new DictItem();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                dictItem = dictItemRepository.Get(id);
                AutoMapper.Mapper.Map<DictItemInputDto, DictItem>(dictItemInputDto, dictItem);
                dictItemRepository.Update(dictItem);
            }
            else
            {
                AutoMapper.Mapper.Map<DictItemInputDto, DictItem>(dictItemInputDto, dictItem);
                dictItem.Id = IdWorkerHelper.GenId64();
                dictItem.DeletedMark = false;
                dictItem.CreationTime = DateTime.Now;
                dictItem.CreatorUserId = 1;
                dictItemRepository.Add(dictItem);
            }
        }
        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            DictItem dictItem = dictItemRepository.Get(id);
            dictItem.DeletedMark = true;
            dictItem.DeletionTime = DateTime.Now;
            dictItemRepository.Update(dictItem);
        }
    }
}
