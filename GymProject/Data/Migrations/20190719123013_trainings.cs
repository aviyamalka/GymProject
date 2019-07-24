using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class trainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortDescription",
                table: "Training",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "shortDescription",
                table: "Training");
        }
    }
}
