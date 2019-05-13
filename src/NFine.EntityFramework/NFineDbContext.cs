using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NFine.EntityFramework.Entity.OAManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.EntityFramework.Entity.SystemSecurity;
using NFine.EntityFramework.Entity.WeixinManage;
using System;
using System.Linq;
using System.Reflection;
namespace NFine.EntityFramework
{
    public class NFineDbContext : DbContext
    {
        //private readonly string _connectionString;

        //public NFineDbContext(IConfiguration configuration) : base()
        //{
        //    _connectionString = configuration.GetConnectionString("MySQLConnection");
        //}

        public NFineDbContext()
        {

        }

        public NFineDbContext(DbContextOptions<NFineDbContext> options) : base(options)
        {

        }

        #region SystemManage DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Organize> Organizes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Dict> Dicts { get; set; }
        public DbSet<DictItem> DictItems { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        #endregion

        #region SystemSecurity      
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<OperateLog> OperateLogs { get; set; }
        #endregion SystemSecurity   

        #region WeixinManage DbSet
        //public DbSet<WxAccount> WxAccounts { get; set; }
        //public DbSet<WxMenu> WxMenus { get; set; }
        //public DbSet<WxUser> WxUsers { get; set; }
        //public DbSet<WxText> WxText { get; set; }
        //public DbSet<WxNews> WxNews { get; set; }
        //public DbSet<WxNewsItem> WxNewsItems { get; set; }
        //public DbSet<WxImage> WxImages { get; set; }
        //public DbSet<WxVoice> WxVoices { get; set; }
        //public DbSet<WxVideo> WxVideos { get; set; }
        #endregion

        #region OAManage DbSet
        //public DbSet<ResFile> ResFiles { get; set; }
        //public DbSet<ResFileRecycle> ResFileRecycles { get; set; }

        //public DbSet<DailyReport> DailyReports { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            foreach (var type in typesToRegister)
            {

                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=47.99.80.79;Database=nfinebase;User Id=root;Password=flyang.net1234;");
            }
        }
    }
}
