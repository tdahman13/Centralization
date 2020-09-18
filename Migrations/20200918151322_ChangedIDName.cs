using Microsoft.EntityFrameworkCore.Migrations;

namespace Centralization.Migrations
{
    public partial class ChangedIDName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemorialApplicationID",
                table: "MemorialApplications",
                newName: "MemorialApplicationId");

            migrationBuilder.RenameColumn(
                name: "LinkedIntermentID",
                table: "LinkedInterments",
                newName: "LinkedIntermentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemorialApplicationId",
                table: "MemorialApplications",
                newName: "MemorialApplicationID");

            migrationBuilder.RenameColumn(
                name: "LinkedIntermentId",
                table: "LinkedInterments",
                newName: "LinkedIntermentID");
        }
    }
}
