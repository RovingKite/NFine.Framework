using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_resource")]
    public class Resource
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
        public string Icon { get; set; }
        [MaxLength(255)]
        public string UrlAddress { get; set; }
        [MaxLength(255)]
        public string Target { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsExpand { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsDisplay { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public int? SortCode { get; set; }
        public bool? DeletedMark { get; set; }
        public bool? EnabledMark { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        [MaxLength(255)]
        public string ObjectType { get; set; }
        public int? Location { get; set; }
        [MaxLength(255)]
        public string JsEvent { get; set; }
        public bool? Split { get; set; }
        [MaxLength(255)]
        public string PermissionCode { get; set; }
        [MaxLength(255)]
        public string Module { get; set; }
    }
}
