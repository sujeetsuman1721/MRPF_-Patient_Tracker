using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
    public partial class thedataismodifiedfuthur : Migration
========
    public partial class servicedb : Migration
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
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
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
                name: "PatientsRegistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PateintId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DateOfRegi = table.Column<DateTime>(nullable: false),
========
                name: "Patient_Infos",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DoctorName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
                    table.PrimaryKey("PK_PatientsRegistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
========
                    table.PrimaryKey("PK_Patient_Infos", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    charge = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
                    table.PrimaryKey("PK_Rooms", x => x.Id);
========
                    table.PrimaryKey("PK_RoomDetails", x => x.Id);
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
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
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
                table: "Rooms",
========
                table: "RoomDetails",
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
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
<<<<<<<< HEAD:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220331104854_the data is modified futhur.cs
                name: "PatientsRegistory");

            migrationBuilder.DropTable(
                name: "Rooms");
========
                name: "Patient_Infos");

            migrationBuilder.DropTable(
                name: "RoomDetails");
>>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7:Maintain_Patient_Info/Maintain_Patient_Info/Migrations/20220330183611_servicedb.cs
        }
    }
}
