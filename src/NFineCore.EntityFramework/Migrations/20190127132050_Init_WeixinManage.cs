using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NFineCore.EntityFramework.Migrations
{
    public partial class Init_WeixinManage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wx_image",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(nullable: true),
                    MediaId = table.Column<string>(nullable: true),
                    MediaUrl = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FileExt = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    ThumbPath = table.Column<string>(nullable: true),
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
                    AppId = table.Column<string>(nullable: true),
                    MenuData = table.Column<string>(nullable: true),
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
                    AppId = table.Column<string>(nullable: true),
                    MediaId = table.Column<string>(nullable: true),
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
                name: "wx_official",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    AppSecret = table.Column<string>(nullable: true),
                    AppType = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    EncodingAESKey = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_wx_official", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wx_text",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
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
                    AppId = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    HeadImgUrl = table.Column<string>(nullable: true),
                    SubscribeTime = table.Column<DateTime>(nullable: true),
                    UnionId = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
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
                name: "wx_newsitem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Digest = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentSourceUrl = table.Column<string>(nullable: true),
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
                name: "wx_menu");

            migrationBuilder.DropTable(
                name: "wx_newsitem");

            migrationBuilder.DropTable(
                name: "wx_official");

            migrationBuilder.DropTable(
                name: "wx_text");

            migrationBuilder.DropTable(
                name: "wx_user");

            migrationBuilder.DropTable(
                name: "wx_news");

            migrationBuilder.DropTable(
                name: "wx_image");
        }
    }
}
