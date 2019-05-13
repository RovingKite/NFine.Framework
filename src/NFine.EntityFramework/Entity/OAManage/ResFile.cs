using NFine.EntityFramework.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.OAManage
{
    [Table("oa_resfile")]
    public class ResFile
    {
        [Key]
        public long Id { get; set; }
        public long ParentId { get; set; }
        [MaxLength(255)]
        public string FileName { get; set; }
        [MaxLength(255)]
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        [MaxLength(255)]
        public string FileExt { get; set; }
        [MaxLength(255)]
        public string ThumbPath { get; set; }
        [MaxLength(255)]
        public string FileType { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
    }
}
