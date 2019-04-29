using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NFineCore.EntityFramework.Migrations
{
    public partial class Add_OA_ResFileRecycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "oa_resfilerecycle",
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
                    table.PrimaryKey("PK_oa_resfilerecycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_oa_resfilerecycle_sys_user_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "sys_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_oa_resfilerecycle_CreatorUserId",
                table: "oa_resfilerecycle",
                column: "CreatorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oa_resfilerecycle");
        }
    }
}
