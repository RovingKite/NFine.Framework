
using AutoMapper;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Repository.SystemManage;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using SharpRepository.Repository.Queries;

namespace NFine.Service.SystemManage
{
    public class ResourceService
    {
        ResourceRepository resourceRepository = new ResourceRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<ResourceGridDto> GetList()
        {
            var specification = new Specification<Resource>(u => u.DeletedMark == false);
            var sortingOtopns = new SortingOptions<Resource, int?>(x => x.SortCode, isDescending: false);
            var list = resourceRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<ResourceGridDto>>(list);
        }

        public List<ResourceGridDto> GetMenuList()
        {
            var specification = new Specification<Resource>(u => u.DeletedMark == false && u.ObjectType == "Menu");
            var sortingOtopns = new SortingOptions<Resource, int?>(x => x.SortCode, isDescending: false);
            var list = resourceRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<ResourceGridDto>>(list);
        }

        public List<ResourceGridDto> GetButtonList()
        {
            var specification = new Specification<Resource>(u => u.DeletedMark == false && u.ObjectType == "Button");
            var list = resourceRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResourceGridDto>>(list);
        }

        public List<ResourceGridDto> GetButtonList(string menuId)
        {
            var specification = new Specification<Resource>(u => u.DeletedMark == false && u.ObjectType == "Button");
            var sortingOtopns = new SortingOptions<Resource, int?>(x => x.SortCode, isDescending: false);
            var list = resourceRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<ResourceGridDto>>(list);
        }

        public List<ResourceGridDto> GetWxMenuList()
        {
            var specification = new Specification<Resource>(u => u.DeletedMark == false && u.ObjectType == "Menu" && u.Module == "Weixin");
            var sortingOtopns = new SortingOptions<Resource, int?>(x => x.SortCode, isDescending: false);
            var list = resourceRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<ResourceGridDto>>(list);
        }

        public ResourceOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            ResourceOutputDto resourceOutputDto = new ResourceOutputDto();
            Resource organize = resourceRepository.Get(id);
            AutoMapper.Mapper.Map<Resource, ResourceOutputDto>(organize, resourceOutputDto);
            return resourceOutputDto;
        }

        public void SubmitForm(ResourceInputDto resourceInputDto, string keyValue)
        {
            Resource resource = new Resource();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                resource = resourceRepository.Get(id);
                AutoMapper.Mapper.Map<ResourceInputDto, Resource>(resourceInputDto, resource);
                resource.ModifiedTime = DateTime.Now;
                resourceRepository.Update(resource);
            }
            else
            {
                AutoMapper.Mapper.Map<ResourceInputDto, Resource>(resourceInputDto, resource);
                resource.Id = IdWorkerHelper.GenId64();
                resource.CreatedTime = DateTime.Now;
                resource.DeletedMark = false;
                resourceRepository.Add(resource);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            Resource resource = resourceRepository.Get(id);
            resource.DeletedMark = true;
            resource.DeletedTime = DateTime.Now;
            resourceRepository.Update(resource);
        }

        public void SubmitCloneButton(string menuId, string ids)
        {
            IList<Resource> resources = new List<Resource>();
            string[] idsArray = ids.Split(',');
            foreach (string id in idsArray)
            {
                Resource resource = resourceRepository.Get(Convert.ToInt64(id));
                resource.Id = IdWorkerHelper.GenId64();
                resource.ParentId = Convert.ToInt64(menuId);
                resource.CreatedTime = System.DateTime.Now;
                resource.DeletedMark = false;
                resource.EnabledMark = true;
                resource.ModifiedTime = null;
                resource.ModifierUserId = null;
                resource.DeletedTime = null;
                resource.DeleterUserId = null;
                resources.Add(resource);
            }
            resourceRepository.Add(resources);
        }
    }
}
