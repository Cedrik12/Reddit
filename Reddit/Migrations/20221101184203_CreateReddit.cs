using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reddit.Migrations
{
    public partial class CreateReddit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "utilisateurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateurs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "liens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    image = table.Column<byte[]>(type: "longblob", nullable: true),
                    title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liens", x => x.id);
                    table.ForeignKey(
                        name: "FK_liens_utilisateurs_userid",
                        column: x => x.userid,
                        principalTable: "utilisateurs",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "commentaires",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    lienid = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaires", x => x.id);
                    table.ForeignKey(
                        name: "FK_commentaires_liens_lienid",
                        column: x => x.lienid,
                        principalTable: "liens",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_commentaires_utilisateurs_userid",
                        column: x => x.userid,
                        principalTable: "utilisateurs",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "votes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    upvote = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    lienid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.id);
                    table.ForeignKey(
                        name: "FK_votes_liens_lienid",
                        column: x => x.lienid,
                        principalTable: "liens",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_votes_utilisateurs_userid",
                        column: x => x.userid,
                        principalTable: "utilisateurs",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "utilisateurs",
                columns: new[] { "id", "email", "password", "username" },
                values: new object[] { 5, "cedrikcool", "yo", "cedrik" });

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_lienid",
                table: "commentaires",
                column: "lienid");

            migrationBuilder.CreateIndex(
                name: "IX_commentaires_userid",
                table: "commentaires",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_liens_userid",
                table: "liens",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_votes_lienid",
                table: "votes",
                column: "lienid");

            migrationBuilder.CreateIndex(
                name: "IX_votes_userid",
                table: "votes",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commentaires");

            migrationBuilder.DropTable(
                name: "votes");

            migrationBuilder.DropTable(
                name: "liens");

            migrationBuilder.DropTable(
                name: "utilisateurs");
        }
    }
}
