using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class updateStratAndEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Branch",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Branch",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Registrant",
                columns: table => new
                {
                    RegistrantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId1 = table.Column<int>(nullable: true),
                    LessonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrant", x => x.RegistrantId);
                    table.ForeignKey(
                        name: "FK_Registrant_Lesson_LessonId1",
                        column: x => x.LessonId1,
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrant_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

         
            migrationBuilder.CreateIndex(
                name: "IX_Registrant_LessonId1",
                table: "Registrant",
                column: "LessonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_UserId1",
                table: "Registrant",
                column: "UserId1");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
      
            migrationBuilder.DropTable(
                name: "Registrant");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Branch",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Branch",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
