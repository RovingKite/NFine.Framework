using NFine.EntityFramework.Entity.SystemManage;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFine.EntityFramework.Entity.OAManage
{
    [Table("oa_dailyreport")]
    public class DailyReport
    {
        [Key]
        public ulong Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(5000)]
        public string Content { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}