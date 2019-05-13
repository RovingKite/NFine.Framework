﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.EntityFramework.Dto.SystemManage
{
    public class RoleOutputDto
    {
        public string FullName { get; set; }
        public string EnCode { get; set; }
        public int? SortCode { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public string Description { get; set; }
        public string ObjectType { get; set; }
        public bool? EnabledMark { get; set; }
        public string OrganizeId { get; set; }
    }
}
