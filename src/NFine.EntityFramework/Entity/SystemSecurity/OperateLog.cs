using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFine.EntityFramework.Entity.SystemSecurity
{
    [Table("sec_operatelog")]
    public class OperateLog
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Method { get; set; }
        public DateTime? OperateTime { get; set; }
        [MaxLength(255)]
        public string Parameter { get; set; }
        [MaxLength(255)]
        public string Area { get; set; }
        [MaxLength(255)]
        public string Controller { get; set; }
        [MaxLength(255)]
        public string Action { get; set; }        
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
