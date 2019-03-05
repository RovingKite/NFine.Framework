using NFineCore.EntityFramework.Entity.WeixinManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dto.WeixinManage
{
    public class WxNewsItemOutputDto
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Digest { get; set; }
        public string Content { get; set; }
        public string ContentSourceUrl { get; set; }
        public int ShowCoverPic { get; set; }
        public int NeedOpenComment { get; set; }
        public int OnlyFansCanComment { get; set; }
        public WxNewsInputDto WxNews { get; set; }
        public WxImageInputDto Thumb { get; set; }
    }
}
