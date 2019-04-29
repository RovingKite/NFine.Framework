
using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Entity.SystemManage;
using NFineCore.Repository.SystemManage;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NFineCore.Core;
using NFineCore.EntityFramework.Dto.OAManage;
using NFineCore.EntityFramework.Entity.OAManage;
using NFineCore.Repository.OAManage;

namespace NFineCore.Service.OAManage
{
    public class ResFileRecycleService : IResFileRecycleService
    {
        ResFileRecycleRepository resFileRecycleRepository = new ResFileRecycleRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public void insert(ResFile resFile)
        {
            
        }
    }
}
