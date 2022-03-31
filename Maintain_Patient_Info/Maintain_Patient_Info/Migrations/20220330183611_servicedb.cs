using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
    public partial class servicedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    DocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.DocId);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestName = table.Column<string>(nullable: true),
                    LabTestResult = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Infos",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DoctorName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Infos", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charge = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Consultation",
                columns: new[] { "DocId", "Charge", "DoctorName", "Purpose" },
                values: new object[,]
                {
                    { 1, 4005, "Hari", "skin Problem" },
                    { 2, 500, "Rahul", "Cardiac CheckUp" },
                    { 3, 450, "Kiran", "Kidney CheckUp" },
                    { 4, 500, "Srikanth", "Sugar CheckUp" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "Charge", "LabTestName", "LabTestResult" },
                values: new object[,]
                {
                    { 1, 150, "Blood Test", "Completed" },
                    { 2, 200, "Creatine Test", "Pending" },
                    { 3, 100, "Prick Test", "Completed" },
                    { 4, 150, "Diabetes Test", "Pending" }
                });

            migrationBuilder.InsertData(
                table: "RoomDetails",
                columns: new[] { "Id", "RoomType", "charge" },
                values: new object[,]
                {
                    { 1, "Single", 4000 },
                    { 2, "Single", 4000 },
                    { 3, "Double", 4000 },
                    { 4, "ICU", 6000 },
                    { 5, "Special Rooms", 6500 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Patient_Infos");

            migrationBuilder.DropTable(
                name: "RoomDetails");
        }
    }
}
