using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultation",
                columns: table => new
                {
                    DocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocName = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true)
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
                    LabTestResult = table.Column<string>(nullable: true)
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
                    Num = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true),
                    NoOfDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
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
