﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using System;
using System.Linq;
using System.Reflection;

namespace NFineCore.EntityFramework
{
    public class NFineCoreDbContext : DbContext
    {
        private readonly string _connectionString;

        public NFineCoreDbContext(IConfiguration configuration) : base()
        {
            _connectionString = configuration.GetConnectionString("MySQLConnection");
        }

        public NFineCoreDbContext(DbContextOptions<NFineCoreDbContext> options) : base(options)
        {

        }
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

        public DbSet<WxOfficial> WxOfficials { get; set; }
        public DbSet<WxMenu> WxMenus { get; set; }
        public DbSet<WxUser> WxUsers { get; set; }
        public DbSet<WxText> WxText { get; set; }
        public DbSet<WxNews> WxNews { get; set; }
        public DbSet<WxNewsItem> WxNewsItems { get; set; }
        public DbSet<WxImage> WxImages { get; set; }

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
                optionsBuilder.UseMySql(_connectionString);
            }
        }
    }
}
