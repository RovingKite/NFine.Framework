using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dtos.WeixinManage
{
    public class WxImageGridDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string MediaId { get; set; }
        public string MediaUrl { get; set; }
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public string FileExt { get; set; }
        public string FilePath { get; set; }
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
