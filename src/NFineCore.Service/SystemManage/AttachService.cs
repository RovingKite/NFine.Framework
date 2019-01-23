
using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Repository.SystemManage;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NFineCore.Service.SystemManage
{
    public class AttachService
    {
        AttachRepository attachRepository = new AttachRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        public List<AttachGridDto> GetList(Pagination pagination, string keyword)
        {
            var specification = new Specification<Attach>(u => u.DeletedMark == false);
            var pagingOptions = new PagingOptions<Attach, DateTime?>(pagination.page, pagination.rows, x => x.CreationTime, isDescending: true);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<Attach>(u => u.DeletedMark == false && (u.FileName.Contains(keyword)));
            }
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = attachRepository.FindAll(specification, pagingOptions).ToList();
            pagination.records = pagingOptions.TotalItems;
            return Mapper.Map<List<AttachGridDto>>(list);
        }

        public void SubmitForm(AttachInputDto attachInputDto, string keyValue)
        {
            Attach attach = new Attach();
            if (!string.IsNullOrEmpty(keyValue))
            {
                //var id = Convert.ToInt64(keyValue);
                //area = areaRepository.Get(id);
                //AutoMapper.Mapper.Map<AreaInputDto, Area>(areaInputDto, area);
                //area.LastModificationTime = DateTime.Now;
                //areaRepository.Update(area);
            }
            else
            {
                AutoMapper.Mapper.Map<AttachInputDto, Attach>(attachInputDto, attach);
                long UserId = Convert.ToInt64(OperatorProvider.Provider.GetCurrent().Id);
                attach.Id = IdWorkerHelper.GenId64();
                attach.DeletedMark = false;
                attach.CreationTime = DateTime.Now;
                attach.CreatorUserId = UserId;
                attachRepository.Add(attach);
            }
        }

        //public void DeleteForm(string keyValue)
        //{
        //    var id = Convert.ToInt64(keyValue);
        //    Area area = areaRepository.Get(id);
        //    area.DeletedMark = true;
        //    area.DeletionTime = DateTime.Now;
        //    areaRepository.Update(area);
        //}
    }
}
