using NFineCore.EntityFramework.Dto.OAManage;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.EntityFramework.Entity.OAManage;
using NFineCore.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.Service.OAManage
{
    public interface IResFileRecycleService
    {
        void insert(ResFile resFile);
    }
}
