using NFine.EntityFramework.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NFine.EntityFramework.Dto.SystemManage
{

    public class UserGridDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }        
        public DateTime? LastLoginTime { get; set; }
        public bool? EnabledMark { get; set; }
        public byte? Gender { get; set; }
        public DateTime? CreatedTime { get; set; }
        public byte? Type { get; set; }
        public string Description { get; set; }
        public OrganizeOutputDto Company { get; set; }
        public OrganizeOutputDto Department { get; set; }
        public string RoleId { get; set; }
        public PositionOutputDto Position { get; set; }
        //public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
