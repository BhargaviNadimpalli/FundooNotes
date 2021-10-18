using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Collaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collaborators",
                columns: table => new
                {
                    ColId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColEmail = table.Column<string>(nullable: false),
                    NotesId = table.Column<int>(nullable: false),
                    notesModelNotesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaborators", x => x.ColId);
                    table.ForeignKey(
                        name: "FK_collaborators_notes_notesModelNotesId",
                        column: x => x.notesModelNotesId,
                        principalTable: "notes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_notesModelNotesId",
                table: "collaborators",
                column: "notesModelNotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collaborators");
        }
    }
}
