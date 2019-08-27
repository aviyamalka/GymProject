using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class ChangeUserClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUsers_Addresses_UserAdressAddressId",
            //    table: "AspNetUsers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Registrant_AspNetUsers_UserIdId",
            //    table: "Registrant");

            //migrationBuilder.DropIndex(
            //    name: "IX_Registrant_UserIdId",
            //    table: "Registrant");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUsers_UserAdressAddressId",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "UserIdId",
            //    table: "Registrant");

            //migrationBuilder.DropColumn(
            //    name: "Age",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "FirstName",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "LastName",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Password",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Phone",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "ProfieImgSrc",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "UserAdressAddressId",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "userId",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Registrant",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfieImgSrc",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAdressAddressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_UserIdId",
                table: "Registrant",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserAdressAddressId",
                table: "AspNetUsers",
                column: "UserAdressAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_UserAdressAddressId",
                table: "AspNetUsers",
                column: "UserAdressAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrant_AspNetUsers_UserIdId",
                table: "Registrant",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
