using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Collaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    ColId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<int>(nullable: false),
                    ColEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {      
                    table.PrimaryKey("PK_models", x => x.ColId);
                    table.ForeignKey(
                        name: "FK_models_notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "notes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_models_NotesId",
                table: "models",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
