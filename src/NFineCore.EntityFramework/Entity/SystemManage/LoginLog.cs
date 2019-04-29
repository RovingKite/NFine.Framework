using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_loginlog")]
    public class LoginLog
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        public DateTime? OperateTime { get; set; }
        [MaxLength(255)]
        public string IpAddress { get; set; }
        [MaxLength(255)]
        public string IpAddressLocation { get; set; }
        [MaxLength(255)]
        public string OperateType { get; set; }
        public bool? OperateResult { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
