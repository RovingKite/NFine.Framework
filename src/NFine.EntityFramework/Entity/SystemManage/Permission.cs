using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.SystemManage
{
    [Table("sys_permission")]
    public class Permission
    {
        [Key]
        public long Id { get; set; }
        public long ResourceId {get;set;}
        [ForeignKey("ResourceId")]
        public Resource Resource { get; set; }
        public long ObjectId { get; set; }
        [MaxLength(255)]
        public string ObjectType { get; set; }
        public int? SortCode { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public long? ModifierUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
