using Microsoft.EntityFrameworkCore.Migrations;

namespace Centralization.Migrations
{
    public partial class RelatedIntermentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idf",
                table: "MemorialApplication");

            migrationBuilder.CreateTable(
                name: "LinkedInterments",
                columns: table => new
                {
                    LinkedIntermentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idf = table.Column<int>(nullable: false),
                    CemNo = table.Column<string>(nullable: true),
                    ApplicationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedInterments", x => x.LinkedIntermentId);
                    table.ForeignKey(
                        name: "FK_LinkedInterments_MemorialApplication_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "MemorialApplication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkedInterments_ApplicationID",
                table: "LinkedInterments",
                column: "ApplicationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedInterments");

            migrationBuilder.AddColumn<int>(
                name: "Idf",
                table: "MemorialApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
