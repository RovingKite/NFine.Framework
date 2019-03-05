﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFineCore.EntityFramework.Dto.SystemManage
{
    public class AreaGridDto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public string SimpleSpelling { get; set; }

        public int? SortCode { get; set; }
        public DateTime? CreationTime { get; set; }
        public bool? EnabledMark { get; set; }
    }
}
