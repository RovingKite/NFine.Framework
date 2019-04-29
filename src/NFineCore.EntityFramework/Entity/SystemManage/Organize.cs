using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_organize")]
    public class Organize
    {
        [Key]
        public long Id { get; set; }
        public long ParentId { get; set; }
        public int? Layers { get; set; }
        [MaxLength(255)]
        public string EnCode { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        [MaxLength(255)]
        public string ShortName { get; set; }
        [MaxLength(255)]
        public string CategoryId { get; set; }
        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string ManagerId { get; set; }
        [MaxLength(255)]
        public string TelePhone { get; set; }
        [MaxLength(255)]
        public string MobilePhone { get; set; }
        [MaxLength(255)]
        public string WeChat { get; set; }
        [MaxLength(255)]
        public string Fax { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string AreaId { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public int? SortCode { get; set; }
        public bool? DeletedMark { get; set; }
        public bool? EnabledMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
