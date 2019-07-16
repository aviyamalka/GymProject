using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.Data.Migrations
{
    public partial class addImagePathToBranch : Migration
    {

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            //migrationBuilder.DropTable(
            //    name: "Branch");

        }


        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                 name: "ImagePath",
                 table: "Branch",
                 nullable: true);




            //migrationBuilder.CreateTable(
            //    name: "Branch",
            //    columns: table => new
            //    {
            //        BranchId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Phone = table.Column<string>(nullable: true),
            //        StartTime = table.Column<TimeSpan>(nullable: false),
            //        EndTime = table.Column<TimeSpan>(nullable: false),
            //        IsBabySitter = table.Column<bool>(nullable: false),
            //        BranchAddressAddressId = table.Column<int>(nullable: true),
            //        ImagePath = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Branch", x => x.BranchId);
            //        table.ForeignKey(
            //            name: "FK_Branch_Addresses_BranchAddressAddressId",
            //            column: x => x.BranchAddressAddressId,
            //            principalTable: "Addresses",
            //            principalColumn: "AddressId",
            //            onDelete: ReferentialAction.Restrict);
            //    });
        }
            

       
    }
}
