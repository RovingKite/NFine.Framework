using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFine.EntityFramework.Dto.SystemSecurity
{
    public class OperateLogGridDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Method { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Parameter { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }        
        public bool? DeletedMark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public long? ModifierUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public string Description { get; set; }
    }
}
