using NFineCore.EntityFramework.Entity.WeixinManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dto.WeixinManage
{
    public class WxNewsOutputDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string MediaId { get; set; }
        public virtual List<WxNewsItemInputDto> WxNewsItems { get; set; }
    }
}
