using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Label : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labels",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LabelName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_labels_notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "notes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_labels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_labels_NotesId",
                table: "labels",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_labels_UserId",
                table: "labels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labels");
        }
    }
}
