
using AutoMapper;
using NFine.Support;
using NFine.EntityFramework;
using NFine.EntityFramework.Dto.SystemSecurity;
using NFine.EntityFramework.Entity.SystemSecurity;
using NFine.Repository.SystemSecurity;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Service.SystemSecurity
{
    public class LoginLogService
    {
        LoginLogRepository loginLogRepository = new LoginLogRepository(SharpRepoConfig.sharpRepoConfig,"efCore");

        public List<LoginLogGridDto> GetList(Pagination pagination, string keyword)
        {
            var specification = new Specification<LoginLog>(u => u.DeletedMark == false);
            var pagingOptions = new PagingOptions<LoginLog, DateTime?>(pagination.page, pagination.rows, x => x.CreatedTime, isDescending: true);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<LoginLog>(u => u.DeletedMark == false && (u.UserName.Contains(keyword)));
            }
            var list = loginLogRepository.FindAll(specification, pagingOptions).ToList();
            pagination.records = pagingOptions.TotalItems;
            return Mapper.Map<List<LoginLogGridDto>>(list);
        }

        public void SubmitForm(LoginLogInputDto loginLogInputDto, string keyValue)
        {
            LoginLog loginLog = new LoginLog();
            if (!string.IsNullOrEmpty(keyValue))
            {

            }
            else
            {
                AutoMapper.Mapper.Map<LoginLogInputDto, LoginLog>(loginLogInputDto, loginLog);
                loginLog.Id = IdWorkerHelper.GenId64();
                loginLog.DeletedMark = false;
                loginLog.CreatedTime = DateTime.Now;
                loginLogRepository.Add(loginLog);
            }
        }
    }
}

