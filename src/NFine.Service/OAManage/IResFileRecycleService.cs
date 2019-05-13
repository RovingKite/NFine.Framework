using NFine.EntityFramework.Dto.OAManage;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.OAManage;
using NFine.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.Service.OAManage
{
    public interface IResFileRecycleService
    {
        void insert(ResFile resFile);
    }
}
