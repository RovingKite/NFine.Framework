using Microsoft.EntityFrameworkCore;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using System;

namespace NFineCore.Data
{
    public class NFineCoreDbContext : DbContext
    {
        public NFineCoreDbContext(DbContextOptions<NFineCoreDbContext> options) : base(options)
        {

        }

        #region SystemManage
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<OperateLog> OperateLogs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Organize> Organizes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Dict> Dicts { get; set; }
        public DbSet<DictItem> DictItems { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Attach> Attaches { get; set; }
        #endregion

        #region WeixinManage
        public DbSet<WxOfficial> WxOfficials { get; set; }
        public DbSet<WxMenu> WxMenus { get; set; }
        public DbSet<WxUser> WxUsers { get; set; }
        public DbSet<WxText> WxText { get; set; }
        public DbSet<WxNews> WxNews { get; set; }
        public DbSet<WxNewsItem> WxNewsItems { get; set; }
        public DbSet<WxImage> WxImages { get; set; }
        #endregion
    }
}
