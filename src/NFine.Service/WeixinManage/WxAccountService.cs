using AutoMapper;
using NFine.EntityFramework;
using NFine.EntityFramework.Dto.WeixinManage;
using NFine.EntityFramework.Entity.WeixinManage;
using NFine.Repository.SystemManage;
using NFine.Repository.WeixinManage;
using NFine.Support;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.EntityFrameworkCore;
using NFine.Core;

namespace NFine.Service.WeixinManage
{
    public class WxAccountService
    {
        WxAccountRepository wxAccountRepository = new WxAccountRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxAccountGridDto> GetList(string keyword)
        {
            //using (var dbContext = new NFineDbContext())
            //{
            //    var tom = dbContext.WxUsers.First(p => p.Nickname == "大白");//第一次从数据库中查询Person实体tom

            //    string query = "SELECT * FROM wx_official";
            //    var dbConnection = dbContext.Database.GetDbConnection();
            //    var aaa = dbConnection.Query<WxOfficial>(query).ToList();
            //}
            OperatorModel operatorModel = OperatorProvider.Provider.GetOperator();
            var specification = new Specification<WxAccount>(p => p.CreatorUserId == operatorModel.Id);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<WxAccount>(p => p.WeChat.Contains(keyword) || p.Name.Contains(keyword));
            }
            var sortingOtopns = new SortingOptions<WxAccount, DateTime?>(x => x.CreationTime, isDescending: false);
            var list = wxAccountRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<WxAccountGridDto>>(list);
        }

        public WxAccountOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxAccountOutputDto wxAccountOutputDto = new WxAccountOutputDto();
            WxAccount wxAccount = wxAccountRepository.Get(id);
            AutoMapper.Mapper.Map<WxAccount, WxAccountOutputDto>(wxAccount, wxAccountOutputDto);
            return wxAccountOutputDto;
        }
        public WxAccount GetEntityByAppId(string appId)
        {
            var specification = new Specification<WxAccount>(p => p.AppId == appId);
            WxAccount wxAccount = wxAccountRepository.Find(specification);
            return wxAccount;
        }

        public void SubmitForm(WxAccountInputDto wxAccountInputDto, string keyValue)
        {
            WxAccount wxAccount = new WxAccount();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                wxAccount = wxAccountRepository.Get(id);
                AutoMapper.Mapper.Map<WxAccountInputDto, WxAccount>(wxAccountInputDto, wxAccount);
                wxAccount.LastModificationTime = DateTime.Now;
                wxAccountRepository.Update(wxAccount);
            }
            else
            {
                AutoMapper.Mapper.Map<WxAccountInputDto, WxAccount>(wxAccountInputDto, wxAccount);
                wxAccount.Id = IdWorkerHelper.GenId64();
                wxAccount.DeletedMark = false;
                wxAccount.CreationTime = DateTime.Now;
                wxAccount.CreatorUserId = 1;
                wxAccountRepository.Add(wxAccount);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxAccount wxAccount = wxAccountRepository.Get(id);
            wxAccount.DeletedMark = true;
            wxAccount.DeletionTime = DateTime.Now;
            wxAccountRepository.Update(wxAccount);
        }
    }
}
