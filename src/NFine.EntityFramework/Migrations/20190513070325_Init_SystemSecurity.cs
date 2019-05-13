using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NFine.EntityFramework.Migrations
{
    public partial class Init_SystemSecurity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sec_loginlog",
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
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<long>(nullable: true),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sec_loginlog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sec_operatelog",
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
                    table.PrimaryKey("PK_sec_operatelog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sec_loginlog");

            migrationBuilder.DropTable(
                name: "sec_operatelog");
        }
    }
}
