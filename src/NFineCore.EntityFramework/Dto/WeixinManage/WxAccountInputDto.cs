using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dto.WeixinManage
{
    public class WxAccountInputDto
    {
        public string Name { get; set; }
        public string WeChat { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AppType { get; set; }
        public string Token { get; set; }
        public string EncodingAESKey { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool? EnabledMark { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
