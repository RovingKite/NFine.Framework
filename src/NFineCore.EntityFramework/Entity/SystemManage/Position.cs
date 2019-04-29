﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_position")]
    public class Position
    {
        [Key]
        public long Id { get; set; }
        public long OrganizeId { get; set; }
        [MaxLength(255)]
        public string EnCode { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public int? SortCode { get; set; }
        public bool? EnabledMark { get; set; }
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
