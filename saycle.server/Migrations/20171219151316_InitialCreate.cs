using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace saycle.server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginID = table.Column<Guid>(nullable: false),
                    Browser = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    StoryID = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    CreatorID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    LanguageID = table.Column<Guid>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.StoryID);
                    table.ForeignKey(
                        name: "FK_Stories_Users_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stories_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    LanguageID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => new { x.UserID, x.LanguageID });
                    table.UniqueConstraint("AK_UserLanguage_LanguageID_UserID", x => new { x.LanguageID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserLanguage_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    BookmarkID = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    StoryID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => x.BookmarkID);
                    table.ForeignKey(
                        name: "FK_Bookmark_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "StoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmark_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    CycleID = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    StoryID = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.CycleID);
                    table.ForeignKey(
                        name: "FK_Cycles_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "StoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cycles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    StoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => new { x.UserID, x.StoryID });
                    table.UniqueConstraint("AK_Favorite_StoryID_UserID", x => new { x.StoryID, x.UserID });
                    table.ForeignKey(
                        name: "FK_Favorite_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "StoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorite_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitID = table.Column<Guid>(nullable: false),
                    StoryID = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK_Visits_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "StoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingID = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    CycleID = table.Column<Guid>(nullable: true),
                    StoryID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Cycles_CycleID",
                        column: x => x.CycleID,
                        principalTable: "Cycles",
                        principalColumn: "CycleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "Stories",
                        principalColumn: "StoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_StoryID",
                table: "Bookmark",
                column: "StoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_UserID",
                table: "Bookmark",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_StoryID",
                table: "Cycles",
                column: "StoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_UserID",
                table: "Cycles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserID",
                table: "Logins",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserID",
                table: "Ratings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CycleID",
                table: "Ratings",
                column: "CycleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StoryID",
                table: "Ratings",
                column: "StoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_CreatorID",
                table: "Stories",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_LanguageID",
                table: "Stories",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_StoryID",
                table: "Visits",
                column: "StoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserID",
                table: "Visits",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmark");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
