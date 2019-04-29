using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NFineCore.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_area",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    Layers = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    SimpleSpelling = table.Column<string>(maxLength: 255, nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dict",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    IsTree = table.Column<bool>(nullable: true),
                    Layers = table.Column<int>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_loginlog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    OperateTime = table.Column<DateTime>(nullable: true),
                    IpAddress = table.Column<string>(maxLength: 255, nullable: true),
                    IpAddressLocation = table.Column<string>(maxLength: 255, nullable: true),
                    OperateType = table.Column<string>(maxLength: 255, nullable: true),
                    OperateResult = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_loginlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_operatelog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    Method = table.Column<string>(maxLength: 255, nullable: true),
                    OperateTime = table.Column<DateTime>(nullable: true),
                    Parameter = table.Column<string>(maxLength: 255, nullable: true),
                    Area = table.Column<string>(maxLength: 255, nullable: true),
                    Controller = table.Column<string>(maxLength: 255, nullable: true),
                    Action = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_operatelog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_organize",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    Layers = table.Column<int>(nullable: true),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    ShortName = table.Column<string>(maxLength: 255, nullable: true),
                    CategoryId = table.Column<string>(maxLength: 255, nullable: true),
                    Type = table.Column<string>(maxLength: 255, nullable: true),
                    ManagerId = table.Column<string>(maxLength: 255, nullable: true),
                    TelePhone = table.Column<string>(maxLength: 255, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 255, nullable: true),
                    WeChat = table.Column<string>(maxLength: 255, nullable: true),
                    Fax = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    AreaId = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    AllowEdit = table.Column<bool>(nullable: true),
                    AllowDelete = table.Column<bool>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_organize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_position",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizeId = table.Column<long>(nullable: false),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    AllowEdit = table.Column<bool>(nullable: true),
                    AllowDelete = table.Column<bool>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_resource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    Layers = table.Column<int>(nullable: true),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    Icon = table.Column<string>(maxLength: 255, nullable: true),
                    UrlAddress = table.Column<string>(maxLength: 255, nullable: true),
                    Target = table.Column<string>(maxLength: 255, nullable: true),
                    IsMenu = table.Column<bool>(nullable: true),
                    IsExpand = table.Column<bool>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: true),
                    IsDisplay = table.Column<bool>(nullable: true),
                    AllowEdit = table.Column<bool>(nullable: true),
                    AllowDelete = table.Column<bool>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    ObjectType = table.Column<string>(maxLength: 255, nullable: true),
                    Location = table.Column<int>(nullable: true),
                    JsEvent = table.Column<string>(maxLength: 255, nullable: true),
                    Split = table.Column<bool>(nullable: true),
                    PermissionCode = table.Column<string>(maxLength: 255, nullable: true),
                    Module = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    WeChat = table.Column<string>(maxLength: 255, nullable: true),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    AppSecret = table.Column<string>(maxLength: 255, nullable: true),
                    AppType = table.Column<string>(maxLength: 255, nullable: true),
                    Token = table.Column<string>(maxLength: 255, nullable: true),
                    EncodingAESKey = table.Column<string>(maxLength: 255, nullable: true),
                    Url = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_image",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaUrl = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FileExt = table.Column<string>(maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(maxLength: 255, nullable: true),
                    ThumbPath = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    MenuData = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_news",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaId = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_news", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_text",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Content = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_text", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_user",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    OpenId = table.Column<string>(maxLength: 255, nullable: true),
                    Nickname = table.Column<string>(maxLength: 255, nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Language = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: true),
                    Province = table.Column<string>(maxLength: 255, nullable: true),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    HeadImgUrl = table.Column<string>(maxLength: 255, nullable: true),
                    SubscribeTime = table.Column<DateTime>(nullable: true),
                    UnionId = table.Column<string>(maxLength: 255, nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    SubscribeStatus = table.Column<int>(nullable: true),
                    TagId = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    SynchronisedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_video",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaUrl = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FileExt = table.Column<string>(maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(maxLength: 255, nullable: true),
                    ThumbPath = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_voice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaId = table.Column<string>(maxLength: 255, nullable: true),
                    MediaUrl = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FileExt = table.Column<string>(maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(maxLength: 255, nullable: true),
                    ThumbPath = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_voice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_dictitem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    ItemCode = table.Column<string>(maxLength: 255, nullable: true),
                    ItemName = table.Column<string>(maxLength: 255, nullable: true),
                    SimpleSpelling = table.Column<string>(maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(nullable: true),
                    Layers = table.Column<int>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DictId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dictitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_dictitem_sys_dict_DictId",
                        column: x => x.DictId,
                        principalTable: "sys_dict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizeId = table.Column<long>(nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    EnCode = table.Column<string>(maxLength: 255, nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    AllowEdit = table.Column<bool>(nullable: true),
                    AllowDelete = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Type = table.Column<string>(maxLength: 255, nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_role_sys_organize_OrganizeId",
                        column: x => x.OrganizeId,
                        principalTable: "sys_organize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    SecretKey = table.Column<string>(maxLength: 255, nullable: true),
                    NickName = table.Column<string>(maxLength: 255, nullable: true),
                    RealName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    TelePhone = table.Column<string>(maxLength: 255, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 255, nullable: true),
                    WeChat = table.Column<string>(maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Type = table.Column<byte>(nullable: true),
                    Gender = table.Column<byte>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    IsAdministrator = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    PositionId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_user_sys_organize_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "sys_organize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_sys_organize_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "sys_organize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_user_sys_position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "sys_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sys_permission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<long>(nullable: false),
                    ObjectId = table.Column<long>(nullable: false),
                    ObjectType = table.Column<string>(maxLength: 255, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_permission_sys_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "sys_resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wx_newsitem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Author = table.Column<string>(maxLength: 255, nullable: true),
                    Digest = table.Column<string>(maxLength: 255, nullable: true),
                    Content = table.Column<string>(maxLength: 255, nullable: true),
                    ContentSourceUrl = table.Column<string>(maxLength: 255, nullable: true),
                    ShowCoverPic = table.Column<int>(nullable: false),
                    NeedOpenComment = table.Column<int>(nullable: false),
                    OnlyFansCanComment = table.Column<int>(nullable: false),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    NewsId = table.Column<long>(nullable: true),
                    ThumbId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wx_newsitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wx_newsitem_wx_news_NewsId",
                        column: x => x.NewsId,
                        principalTable: "wx_news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_wx_newsitem_wx_image_ThumbId",
                        column: x => x.ThumbId,
                        principalTable: "wx_image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oa_resfile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<long>(nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(maxLength: 255, nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    FileExt = table.Column<string>(maxLength: 255, nullable: true),
                    ThumbPath = table.Column<string>(maxLength: 255, nullable: true),
                    FileType = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oa_resfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_oa_resfile_sys_user_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sys_userrole",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    DeletedMark = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_userrole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_sys_userrole_sys_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "sys_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_userrole_sys_user_UserId",
                        column: x => x.UserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_oa_resfile_CreatorUserId",
                table: "oa_resfile",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_dictitem_DictId",
                table: "sys_dictitem",
                column: "DictId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_permission_ResourceId",
                table: "sys_permission",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_OrganizeId",
                table: "sys_role",
                column: "OrganizeId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_CompanyId",
                table: "sys_user",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_DepartmentId",
                table: "sys_user",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_user_PositionId",
                table: "sys_user",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_userrole_RoleId",
                table: "sys_userrole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_wx_newsitem_NewsId",
                table: "wx_newsitem",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_wx_newsitem_ThumbId",
                table: "wx_newsitem",
                column: "ThumbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oa_resfile");

            migrationBuilder.DropTable(
                name: "sys_area");

            migrationBuilder.DropTable(
                name: "sys_dictitem");

            migrationBuilder.DropTable(
                name: "sys_loginlog");

            migrationBuilder.DropTable(
                name: "sys_operatelog");

            migrationBuilder.DropTable(
                name: "sys_permission");

            migrationBuilder.DropTable(
                name: "sys_userrole");

            migrationBuilder.DropTable(
                name: "wx_account");

            migrationBuilder.DropTable(
                name: "wx_menu");

            migrationBuilder.DropTable(
                name: "wx_newsitem");

            migrationBuilder.DropTable(
                name: "wx_text");

            migrationBuilder.DropTable(
                name: "wx_user");

            migrationBuilder.DropTable(
                name: "wx_video");

            migrationBuilder.DropTable(
                name: "wx_voice");

            migrationBuilder.DropTable(
                name: "sys_dict");

            migrationBuilder.DropTable(
                name: "sys_resource");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "wx_news");

            migrationBuilder.DropTable(
                name: "wx_image");

            migrationBuilder.DropTable(
                name: "sys_organize");

            migrationBuilder.DropTable(
                name: "sys_position");
        }
    }
}
