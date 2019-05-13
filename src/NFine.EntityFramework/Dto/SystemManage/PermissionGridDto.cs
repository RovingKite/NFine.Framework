using NFine.EntityFramework.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Dto.SystemManage
{

    public class PermissionGridDto
    {
        public string Id { get; set; }
        public string ResourceId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectType { get; set; }
        public DateTime? CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public long? ModifierUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public int? SortCode { get; set; }
        public bool? DeletedMark { get; set; }
    }
}
