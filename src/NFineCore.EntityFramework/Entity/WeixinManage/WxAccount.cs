using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.WeixinManage
{
    public class WxAccount
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string WeChat { get; set; }
        [MaxLength(255)]
        public string AppId { get; set; }
        [MaxLength(255)]
        public string AppSecret { get; set; }
        [MaxLength(255)]
        public string AppType { get; set; }
        [MaxLength(255)]
        public string Token { get; set; }
        [MaxLength(255)]
        public string EncodingAESKey { get; set; }
        [MaxLength(255)]
        public string Url { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
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
