using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.Service.SystemManage
{
    public interface IAttachService
    {
        List<AttachGridDto> GetList(Pagination pagination, string keyword);

        void SubmitForm(AttachInputDto attachInputDto, string keyValue);

        void DeleteForm(string keyValue);
    }
}
