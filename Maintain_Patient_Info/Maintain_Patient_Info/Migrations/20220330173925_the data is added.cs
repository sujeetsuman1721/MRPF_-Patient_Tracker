using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
    public partial class thedataisadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultation",
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
                    table.PrimaryKey("PK_consultation", x => x.DocId);
                });

            migrationBuilder.CreateTable(
                name: "labTests",
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
                    table.PrimaryKey("PK_labTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patient_infos",
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
                    table.PrimaryKey("PK_patient_infos", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "prescriptionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<string>(nullable: true),
                    MedicineDetails = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charge = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "consultation",
                columns: new[] { "DocId", "Charge", "DoctorName", "Purpose" },
                values: new object[,]
                {
                    { 1, 4005, "Hari", "skin Problem" },
                    { 2, 500, "Rahul", "Headache" },
                    { 3, 450, "Kiran", "Fever" },
                    { 4, 500, "Srikanth", "Stomach Pain" }
                });

            migrationBuilder.InsertData(
                table: "labTests",
                columns: new[] { "Id", "Charge", "LabTestName", "LabTestResult" },
                values: new object[,]
                {
                    { 1, 150, "Blood Test", "Completed" },
                    { 2, 200, "Creatine Test", "Pending" },
                    { 3, 100, "Lipid Profile", "Completed" },
                    { 4, 150, "Diabetes Test", "Pending" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
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
                name: "consultation");

            migrationBuilder.DropTable(
                name: "labTests");

            migrationBuilder.DropTable(
                name: "patient_infos");

            migrationBuilder.DropTable(
                name: "prescriptionDetails");

            migrationBuilder.DropTable(
                name: "rooms");
        }
    }
}
