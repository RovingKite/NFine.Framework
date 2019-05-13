using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NFine.EntityFramework.Entity.SystemManage
{
    [Table("sys_userrole")]
    public class UserRole
    {
        public long UserId { get; set; }
        public virtual User User { set; get; }
        public long RoleId { get; set; }        
        public virtual Role Role { set; get; }
        public bool? DeletedMark { get; set; }
    }
}
