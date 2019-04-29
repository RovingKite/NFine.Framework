﻿using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.EntityFramework.Entity.WeixinManage;
using SharpRepository.Repository;
using SharpRepository.Repository.Configuration;

namespace NFineCore.Repository.WeixinManage
{
    public class WxAccountRepository : ConfigurationBasedRepository<WxAccount, long>
    {
        public WxAccountRepository(ISharpRepositoryConfiguration configuration, string repositoryName = null) : base(configuration, repositoryName)
        {

        }
    }
}