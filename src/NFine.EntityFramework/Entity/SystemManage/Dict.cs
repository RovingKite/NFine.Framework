using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.SystemManage
{
    [Table("sys_dict")]
    public class Dict
    {
        [Key]
        public long Id { get; set; }
        public long ParentId { get; set; }
        [MaxLength(255)]
        public string EnCode { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        public bool? IsTree { get; set; }
        public int? Layers { get; set; }
        public int? SortCode { get; set; }
        public bool? EnabledMark { get; set; }
        public bool? DeletedMark { get; set; }
        public virtual ICollection<DictItem> DictItems { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public long? ModifierUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
