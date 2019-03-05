﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFineCore.EntityFramework.Dto.SystemManage
{
    public class DictGridDto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public int? SortCode { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }
    }
}
