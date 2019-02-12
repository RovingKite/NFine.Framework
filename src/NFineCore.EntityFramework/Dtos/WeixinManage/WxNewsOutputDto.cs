using NFineCore.EntityFramework.Models.WeixinManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.EntityFramework.Dtos.WeixinManage
{
    public class WxNewsOutputDto
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string MediaId { get; set; }
        public virtual List<WxNewsItemInputDto> WxNewsItems { get; set; }
    }
}
