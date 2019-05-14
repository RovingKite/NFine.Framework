using NFine.EntityFramework.Dto.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.SystemManage
{
    [Table("sys_role")]
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public long? OrganizeId { get;set;}
        [ForeignKey("OrganizeId")]
        public Organize Organize { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        [MaxLength(255)]
        public string EnCode { get; set; }
        public int? SortCode { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        [MaxLength(255)]
        public string ObjectType { get; set; }
        public bool? EnabledMark { get; set; }
        public bool? DeletedMark { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
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
