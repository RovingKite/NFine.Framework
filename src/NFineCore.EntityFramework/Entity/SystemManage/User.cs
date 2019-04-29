using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFineCore.EntityFramework.Entity.SystemManage
{
    [Table("sys_user")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(255)]
        public string SecretKey { get; set; }
        [MaxLength(255)]
        public string NickName { get; set; }
        [MaxLength(255)]
        public string RealName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string TelePhone { get; set; }
        [MaxLength(255)]
        public string MobilePhone { get; set; }
        [MaxLength(255)]
        public string WeChat { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Type { get; set; }
        public byte? Gender { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool? EnabledMark { get; set; }
        public bool? DeletedMark { get; set; }
        public bool? IsAdministrator { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Organize Company { get; set; }
        public long DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Organize Department { get; set; }
        public long PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
