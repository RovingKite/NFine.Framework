using NFine.EntityFramework.Entity.WeixinManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.EntityFramework.Dto.WeixinManage
{
    public class WxNewsInputDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string MediaId { get; set; }
        public virtual List<WxNewsItemInputDto> WxNewsItems { get; set; }
    }
}
