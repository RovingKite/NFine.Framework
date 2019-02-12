using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dtos.WeixinManage
{
    public class WxTextGridDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? DeletedMark { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
