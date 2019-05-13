
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
using System.Threading;
using NFine.Core;
using NFine.EntityFramework.Dto.OAManage;
using NFine.EntityFramework.Entity.OAManage;
using NFine.Repository.OAManage;

namespace NFine.Service.OAManage
{
    public class ResFileRecycleService : IResFileRecycleService
    {
        ResFileRecycleRepository resFileRecycleRepository = new ResFileRecycleRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public void insert(ResFile resFile)
        {
            
        }
    }
}
