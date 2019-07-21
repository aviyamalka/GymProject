using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class Trainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "shortDescription",
                table: "Training",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shortDescription",
                table: "Training");
        }
    }
}
