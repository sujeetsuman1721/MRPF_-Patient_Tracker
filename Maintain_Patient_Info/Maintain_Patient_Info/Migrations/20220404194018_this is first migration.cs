using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
    public partial class thisisfirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ConsultationId);
                });

            migrationBuilder.CreateTable(
                name: "Facilites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    ConsultationId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    LabTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    LabTestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestName = table.Column<string>(nullable: true),
                    LabTestResult = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.LabTestId);
                });

            migrationBuilder.CreateTable(
                name: "PatientsRegistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PateintId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DateOfRegi = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Priscription = table.Column<string>(nullable: true),
                    ExerciseOrDiet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsRegistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charge = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.InsertData(
                table: "Consultation",
                columns: new[] { "ConsultationId", "Charge", "Purpose" },
                values: new object[,]
                {
                    { 1, 4005, "skin Problem" },
                    { 2, 500, "Cardiac CheckUp" },
                    { 3, 450, "Kidney CheckUp" },
                    { 4, 500, "Sugar CheckUp" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "LabTestId", "Charge", "LabTestName", "LabTestResult" },
                values: new object[,]
                {
                    { 1, 150, "Blood Test", "Pending" },
                    { 2, 200, "Creatine Test", "Pending" },
                    { 3, 100, "Prick Test", "Completed" },
                    { 4, 150, "Diabetes Test", "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Charge", "RoomType" },
                values: new object[,]
                {
                    { 1, 4000, "Single" },
                    { 2, 4000, "Single" },
                    { 3, 4000, "Double" },
                    { 4, 6000, "ICU" },
                    { 5, 6500, "Special Rooms" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Facilites");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "PatientsRegistory");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
