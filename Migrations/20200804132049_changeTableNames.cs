using Microsoft.EntityFrameworkCore.Migrations;

namespace Centralization.Migrations
{
    public partial class changeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplication_ApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemorialApplication",
                table: "MemorialApplication");

            migrationBuilder.RenameTable(
                name: "MemorialApplication",
                newName: "MemorialApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_ApplicationID",
                table: "LinkedInterments",
                column: "ApplicationID",
                principalTable: "MemorialApplications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_ApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications");

            migrationBuilder.RenameTable(
                name: "MemorialApplications",
                newName: "MemorialApplication");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemorialApplication",
                table: "MemorialApplication",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplication_ApplicationID",
                table: "LinkedInterments",
                column: "ApplicationID",
                principalTable: "MemorialApplication",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
