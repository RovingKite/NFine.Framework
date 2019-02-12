using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dtos.WeixinManage
{
    public class WxUserSubscribeDto
    {
        public string AppId { get; set; }
        public string OpenId { get; set; }
        public DateTime? SubscribeTime { get; set; }
        public int? SubscribeStatus { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
