using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.EntityFramework.Dto.WeixinManage
{
    public class WxUserGridDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string OpenId { get; set; }
        public string Nickname { get; set; }
        public int? Sex { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string HeadImgUrl { get; set; }
        public DateTime? SubscribeTime { get; set; }
        public string UnionId { get; set; }
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
