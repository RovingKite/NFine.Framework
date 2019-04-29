using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_dictitem")]
    public class DictItem
    {
        [Key]
        public long Id { get; set; }
        public long ParentId { get; set; }
        [MaxLength(255)]
        public string ItemCode { get; set; }
        [MaxLength(255)]
        public string ItemName { get; set; }
        [MaxLength(255)]
        public string SimpleSpelling { get; set; }
        public bool? IsDefault { get; set; }
        public int? Layers { get; set; }
        public int? SortCode { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public bool? EnabledMark { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        public long DictId { get; set; }
        public Dict Dict { get; set; }
    }
}
