using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class yaelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrant",
                columns: table => new
                {
                    RegistrantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserIdId = table.Column<string>(nullable: true),
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
                        name: "FK_Registrant_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_LessonId1",
                table: "Registrant",
                column: "LessonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Registrant_UserIdId",
                table: "Registrant",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrant");
        }
    }
}
