﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.EntityFramework.Dto.SystemManage
{
    public class DictItemGridDto
    {
        public string Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? SortCode { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }
        public string DictId { get; set; }
    }
}
