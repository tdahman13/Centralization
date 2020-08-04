using Microsoft.EntityFrameworkCore.Migrations;

namespace Centralization.Migrations
{
    public partial class updateIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_ApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications");

            migrationBuilder.DropIndex(
                name: "IX_LinkedInterments_ApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MemorialApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "LinkedInterments");

            migrationBuilder.RenameColumn(
                name: "LinkedIntermentId",
                table: "LinkedInterments",
                newName: "LinkedIntermentID");

            migrationBuilder.AddColumn<int>(
                name: "MemorialApplicationID",
                table: "MemorialApplications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MemorialApplicationID",
                table: "LinkedInterments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications",
                column: "MemorialApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedInterments_MemorialApplicationID",
                table: "LinkedInterments",
                column: "MemorialApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationID",
                table: "LinkedInterments",
                column: "MemorialApplicationID",
                principalTable: "MemorialApplications",
                principalColumn: "MemorialApplicationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications");

            migrationBuilder.DropIndex(
                name: "IX_LinkedInterments_MemorialApplicationID",
                table: "LinkedInterments");

            migrationBuilder.DropColumn(
                name: "MemorialApplicationID",
                table: "MemorialApplications");

            migrationBuilder.DropColumn(
                name: "MemorialApplicationID",
                table: "LinkedInterments");

            migrationBuilder.RenameColumn(
                name: "LinkedIntermentID",
                table: "LinkedInterments",
                newName: "LinkedIntermentId");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MemorialApplications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "LinkedInterments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemorialApplications",
                table: "MemorialApplications",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedInterments_ApplicationID",
                table: "LinkedInterments",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_ApplicationID",
                table: "LinkedInterments",
                column: "ApplicationID",
                principalTable: "MemorialApplications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
