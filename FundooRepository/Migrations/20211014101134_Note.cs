using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    NotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Remainder = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Is_Archive = table.Column<bool>(nullable: false),
                    Is_Trash = table.Column<bool>(nullable: false),
                    Is_Pin = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserModelUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_notes_Users_UserModelUserId",
                        column: x => x.UserModelUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notes_UserModelUserId",
                table: "notes",
                column: "UserModelUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes");
        }
    }
}
