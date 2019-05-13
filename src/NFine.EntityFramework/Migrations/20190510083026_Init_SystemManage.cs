using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NFine.EntityFramework.Migrations
{
    public partial class Init_SystemManage : Migration
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
                    SortCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
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
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dict", x => x.Id);
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
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
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
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
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
                    ObjectType = table.Column<string>(maxLength: 255, nullable: true),
                    Location = table.Column<int>(nullable: true),
                    JsEvent = table.Column<string>(maxLength: 255, nullable: true),
                    Split = table.Column<bool>(nullable: true),
                    PermissionCode = table.Column<string>(maxLength: 255, nullable: true),
                    Module = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_resource", x => x.Id);
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
                    IsDefault = table.Column<bool>(nullable: true),
                    Layers = table.Column<int>(nullable: true),
                    SortCode = table.Column<int>(nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    DictId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
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
                    Type = table.Column<string>(maxLength: 255, nullable: true),
                    EnabledMark = table.Column<bool>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
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
                    CompanyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    PositionId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
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
                    SortCode = table.Column<int>(nullable: true),
                    DeletedMark = table.Column<bool>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_area");

            migrationBuilder.DropTable(
                name: "sys_dictitem");

            migrationBuilder.DropTable(
                name: "sys_permission");

            migrationBuilder.DropTable(
                name: "sys_userrole");

            migrationBuilder.DropTable(
                name: "sys_dict");

            migrationBuilder.DropTable(
                name: "sys_resource");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "sys_organize");

            migrationBuilder.DropTable(
                name: "sys_position");
        }
    }
}
