﻿using NFine.EntityFramework.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Dto.SystemManage
{

    public class ResourceOutputDto
    {
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }
        public string Icon { get; set; }
        public string UrlAddress { get; set; }
        public string Target { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsExpand { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsDisplay { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
        public int? SortCode { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ObjectType { get; set; }
        public int? Location { get; set; }
        public string JsEvent { get; set; }
        public bool? Split { get; set; }
        public string PermissionCode { get; set; }
        public string Module { get; set; }
    }
}
