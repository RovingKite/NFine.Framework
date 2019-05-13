using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.WeixinManage
{
    public class WxImage
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string AppId { get; set; }
        [MaxLength(255)]
        public string MediaId { get; set; }
        [MaxLength(255)]
        public string MediaUrl { get; set; }
        [MaxLength(255)]
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        [MaxLength(255)]
        public string FileExt { get; set; }
        [MaxLength(255)]
        public string FilePath { get; set; }
        [MaxLength(255)]
        public string ThumbPath { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
