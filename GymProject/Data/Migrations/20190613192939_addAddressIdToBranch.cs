using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class addAddressIdToBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Addresses_addressId",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "Branch",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_addressId",
                table: "Branch",
                newName: "IX_Branch_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Addresses_AddressId",
                table: "Branch",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Addresses_AddressId",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Branch",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_AddressId",
                table: "Branch",
                newName: "IX_Branch_addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Addresses_addressId",
                table: "Branch",
                column: "addressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
