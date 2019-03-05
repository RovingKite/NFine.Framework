using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFineCore.EntityFramework.Entity.WeixinManage
{
    public class WxOfficial
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AppType { get; set; }
        public string Token { get; set; }
        public string EncodingAESKey { get; set; }
        public string Url { get; set; }
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
