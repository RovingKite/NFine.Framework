using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.Core
{
    public class OperatorModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string NickName { get; set; }
        public byte? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string TelePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string WeChat { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string RoleIds { get; set; }
        public string RoleNames { get; set; }
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public byte? Type { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }
        public WxAccountModel WxAccountModel { get; set; }

    }
}
