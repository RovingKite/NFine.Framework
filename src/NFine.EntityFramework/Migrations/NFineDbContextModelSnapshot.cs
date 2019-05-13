﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NFine.EntityFramework;

namespace NFine.EntityFramework.Migrations
{
    [DbContext(typeof(NFineDbContext))]
    partial class NFineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<int?>("Layers");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("ParentId");

                    b.Property<int?>("SortCode");

                    b.HasKey("Id");

                    b.ToTable("sys_area");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Dict", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<bool?>("IsTree");

                    b.Property<int?>("Layers");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("ParentId");

                    b.Property<int?>("SortCode");

                    b.HasKey("Id");

                    b.ToTable("sys_dict");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.DictItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<long>("DictId");

                    b.Property<bool?>("EnabledMark");

                    b.Property<bool?>("IsDefault");

                    b.Property<string>("ItemCode")
                        .HasMaxLength(255);

                    b.Property<string>("ItemName")
                        .HasMaxLength(255);

                    b.Property<int?>("Layers");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("ParentId");

                    b.Property<int?>("SortCode");

                    b.HasKey("Id");

                    b.HasIndex("DictId");

                    b.ToTable("sys_dictitem");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Organize", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<bool?>("AllowDelete");

                    b.Property<bool?>("AllowEdit");

                    b.Property<string>("AreaId")
                        .HasMaxLength(255);

                    b.Property<string>("CategoryId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("Fax")
                        .HasMaxLength(255);

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<int?>("Layers");

                    b.Property<string>("ManagerId")
                        .HasMaxLength(255);

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("ParentId");

                    b.Property<string>("ShortName")
                        .HasMaxLength(255);

                    b.Property<int?>("SortCode");

                    b.Property<string>("TelePhone")
                        .HasMaxLength(255);

                    b.Property<string>("Type")
                        .HasMaxLength(255);

                    b.Property<string>("WeChat")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("sys_organize");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("ObjectId");

                    b.Property<string>("ObjectType")
                        .HasMaxLength(255);

                    b.Property<long>("ResourceId");

                    b.Property<int?>("SortCode");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("sys_permission");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AllowDelete");

                    b.Property<bool?>("AllowEdit");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("OrganizeId");

                    b.Property<int?>("SortCode");

                    b.HasKey("Id");

                    b.ToTable("sys_position");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AllowDelete");

                    b.Property<bool?>("AllowEdit");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<string>("Icon")
                        .HasMaxLength(255);

                    b.Property<bool?>("IsDisplay");

                    b.Property<bool?>("IsExpand");

                    b.Property<bool?>("IsMenu");

                    b.Property<bool?>("IsPublic");

                    b.Property<string>("JsEvent")
                        .HasMaxLength(255);

                    b.Property<int?>("Layers");

                    b.Property<int?>("Location");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Module")
                        .HasMaxLength(255);

                    b.Property<string>("ObjectType")
                        .HasMaxLength(255);

                    b.Property<long>("ParentId");

                    b.Property<string>("PermissionCode")
                        .HasMaxLength(255);

                    b.Property<int?>("SortCode");

                    b.Property<bool?>("Split");

                    b.Property<string>("Target")
                        .HasMaxLength(255);

                    b.Property<string>("UrlAddress")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("sys_resource");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AllowDelete");

                    b.Property<bool?>("AllowEdit");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("EnCode")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("FullName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<long?>("OrganizeId");

                    b.Property<int?>("SortCode");

                    b.Property<string>("ObjectType")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("OrganizeId");

                    b.ToTable("sys_role");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<long>("CompanyId");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<long>("DepartmentId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<byte?>("Gender");

                    b.Property<bool?>("IsAdministrator");

                    b.Property<DateTime?>("LastLoginTime");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("NickName")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasMaxLength(255);

                    b.Property<long>("PositionId");

                    b.Property<string>("RealName")
                        .HasMaxLength(255);

                    b.Property<string>("SecretKey")
                        .HasMaxLength(255);

                    b.Property<string>("TelePhone")
                        .HasMaxLength(255);

                    b.Property<byte?>("Type");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.Property<string>("WeChat")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("sys_user");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.UserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.Property<bool?>("DeletedMark");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("sys_userrole");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemSecurity.LoginLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<DateTime?>("DeletedTime");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("IpAddress")
                        .HasMaxLength(255);

                    b.Property<string>("IpAddressLocation")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<long?>("ModifierUserId");

                    b.Property<bool?>("OperateResult");

                    b.Property<DateTime?>("OperateTime");

                    b.Property<string>("OperateType")
                        .HasMaxLength(255);

                    b.Property<long>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("sec_loginlog");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemSecurity.OperateLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .HasMaxLength(255);

                    b.Property<string>("Area")
                        .HasMaxLength(255);

                    b.Property<string>("Controller")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Method")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("OperateTime");

                    b.Property<string>("Parameter")
                        .HasMaxLength(255);

                    b.Property<long>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("sec_operatelog");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<string>("AppSecret")
                        .HasMaxLength(255);

                    b.Property<string>("AppType")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("EncodingAESKey")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Token")
                        .HasMaxLength(255);

                    b.Property<string>("Url")
                        .HasMaxLength(255);

                    b.Property<string>("WeChat")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_account");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FileExt")
                        .HasMaxLength(255);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<string>("FilePath")
                        .HasMaxLength(255);

                    b.Property<long?>("FileSize");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MediaId")
                        .HasMaxLength(255);

                    b.Property<string>("MediaUrl")
                        .HasMaxLength(255);

                    b.Property<string>("ThumbPath")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_image");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MenuData")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_menu");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxNews", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MediaId")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_news");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxNewsItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .HasMaxLength(255);

                    b.Property<string>("Content")
                        .HasMaxLength(255);

                    b.Property<string>("ContentSourceUrl")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Digest")
                        .HasMaxLength(255);

                    b.Property<int>("Index");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("NeedOpenComment");

                    b.Property<long?>("NewsId");

                    b.Property<int>("OnlyFansCanComment");

                    b.Property<int>("ShowCoverPic");

                    b.Property<long?>("ThumbId");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("ThumbId");

                    b.ToTable("wx_newsitem");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxOfficial", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("AppId");

                    b.Property<string>("AppSecret");

                    b.Property<string>("AppType");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Description");

                    b.Property<bool?>("EnabledMark");

                    b.Property<string>("EncodingAESKey");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name");

                    b.Property<string>("Token");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("wx_official");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxText", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<string>("Content")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_text");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<int?>("GroupId");

                    b.Property<string>("HeadImgUrl")
                        .HasMaxLength(255);

                    b.Property<string>("Language")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Nickname")
                        .HasMaxLength(255);

                    b.Property<string>("OpenId")
                        .HasMaxLength(255);

                    b.Property<string>("Province")
                        .HasMaxLength(255);

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<int?>("Sex");

                    b.Property<int?>("SubscribeStatus");

                    b.Property<DateTime?>("SubscribeTime");

                    b.Property<DateTime?>("SynchronisedTime");

                    b.Property<string>("TagId");

                    b.Property<string>("UnionId")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_user");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxVideo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FileExt")
                        .HasMaxLength(255);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<string>("FilePath")
                        .HasMaxLength(255);

                    b.Property<long?>("FileSize");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MediaId")
                        .HasMaxLength(255);

                    b.Property<string>("MediaUrl")
                        .HasMaxLength(255);

                    b.Property<string>("ThumbPath")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_video");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxVoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppId")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool?>("DeletedMark");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FileExt")
                        .HasMaxLength(255);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<string>("FilePath")
                        .HasMaxLength(255);

                    b.Property<long?>("FileSize");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MediaId")
                        .HasMaxLength(255);

                    b.Property<string>("MediaUrl")
                        .HasMaxLength(255);

                    b.Property<string>("ThumbPath")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wx_voice");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.DictItem", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Dict", "Dict")
                        .WithMany("DictItems")
                        .HasForeignKey("DictId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Permission", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.Role", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Organize", "Organize")
                        .WithMany()
                        .HasForeignKey("OrganizeId");
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.User", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Organize", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Organize", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.SystemManage.UserRole", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NFine.EntityFramework.Entity.SystemManage.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NFine.EntityFramework.Entity.WeixinManage.WxNewsItem", b =>
                {
                    b.HasOne("NFine.EntityFramework.Entity.WeixinManage.WxNews", "WxNews")
                        .WithMany("WxNewsItems")
                        .HasForeignKey("NewsId");

                    b.HasOne("NFine.EntityFramework.Entity.WeixinManage.WxImage", "Thumb")
                        .WithMany()
                        .HasForeignKey("ThumbId");
                });
#pragma warning restore 612, 618
        }
    }
}