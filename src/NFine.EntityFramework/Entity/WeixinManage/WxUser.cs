using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Entity.WeixinManage
{
    public class WxUser
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string AppId { get; set; }
        [MaxLength(255)]
        public string OpenId { get; set; }
        [MaxLength(255)]
        public string Nickname { get; set; }
        public int? Sex { get; set; }
        [MaxLength(255)]
        public string Language { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        [MaxLength(255)]
        public string Province { get; set; }
        [MaxLength(255)]
        public string Country { get; set; }
        [MaxLength(255)]
        public string HeadImgUrl { get; set; }
        public DateTime? SubscribeTime { get; set; }
        [MaxLength(255)]
        public string UnionId { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public int? GroupId { get; set; }
        public int? SubscribeStatus { get; set; }
        public string TagId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? SynchronisedTime { get; set; }
    }
}
