using Microsoft.EntityFrameworkCore.Migrations;

namespace Centralization.Migrations
{
    public partial class ChangedIDNameLinked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationID",
                table: "LinkedInterments");

            migrationBuilder.RenameColumn(
                name: "MemorialApplicationID",
                table: "LinkedInterments",
                newName: "MemorialApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_LinkedInterments_MemorialApplicationID",
                table: "LinkedInterments",
                newName: "IX_LinkedInterments_MemorialApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationId",
                table: "LinkedInterments",
                column: "MemorialApplicationId",
                principalTable: "MemorialApplications",
                principalColumn: "MemorialApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationId",
                table: "LinkedInterments");

            migrationBuilder.RenameColumn(
                name: "MemorialApplicationId",
                table: "LinkedInterments",
                newName: "MemorialApplicationID");

            migrationBuilder.RenameIndex(
                name: "IX_LinkedInterments_MemorialApplicationId",
                table: "LinkedInterments",
                newName: "IX_LinkedInterments_MemorialApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkedInterments_MemorialApplications_MemorialApplicationID",
                table: "LinkedInterments",
                column: "MemorialApplicationID",
                principalTable: "MemorialApplications",
                principalColumn: "MemorialApplicationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
