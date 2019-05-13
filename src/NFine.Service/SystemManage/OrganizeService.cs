
using AutoMapper;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Repository.SystemManage;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Service.SystemManage
{
    public class OrganizeService
    {
        OrganizeRepository organizeRepository = new OrganizeRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<OrganizeGridDto> GetList()
        {
            var specification = new Specification<Organize>(u => u.DeletedMark == false);
            var sortingOtopns = new SortingOptions<Organize, int?>(x => x.SortCode, isDescending: true);
            var list = organizeRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<OrganizeGridDto>>(list);
        }

        public OrganizeOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            OrganizeOutputDto organizeOutputDto = new OrganizeOutputDto();
            Organize organize = organizeRepository.Get(id);
            AutoMapper.Mapper.Map<Organize, OrganizeOutputDto>(organize, organizeOutputDto);
            return organizeOutputDto;
        }

        public void SubmitForm(OrganizeInputDto organizeInputDto, string keyValue)
        {
            Organize organize = new Organize();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                organize = organizeRepository.Get(id);
                AutoMapper.Mapper.Map<OrganizeInputDto, Organize>(organizeInputDto, organize);
                organize.ModifiedTime = DateTime.Now;
                organizeRepository.Update(organize);
            }
            else
            {
                AutoMapper.Mapper.Map<OrganizeInputDto, Organize>(organizeInputDto, organize);
                organize.Id = IdWorkerHelper.GenId64();
                organize.DeletedMark = false;
                organize.CreatedTime = DateTime.Now;
                organizeRepository.Add(organize);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            Organize organize = organizeRepository.Get(id);
            organize.DeletedMark = true;
            organize.DeletedTime = DateTime.Now;
            organizeRepository.Update(organize);
        }
    }
}
