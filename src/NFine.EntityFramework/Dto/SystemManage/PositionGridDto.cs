﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.EntityFramework.Dto.SystemManage
{
    public class PositionGridDto
    {
        public string Id { get; set; }
        public OrganizeOutputDto Organize { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public int? SortCode { get; set; }
        public bool? DeletedMark { get; set; }
        public bool? EnabledMark { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Description { get; set; }
    }
}
