using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuringApplication.Migrations
{
    public partial class thedataisadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patiennt_AspNetUsers_ApplicationUserId",
                table: "Patiennt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt");

            migrationBuilder.RenameTable(
                name: "Patiennt",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_Patiennt_ApplicationUserId",
                table: "Patient",
                newName: "IX_Patient_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_AspNetUsers_ApplicationUserId",
                table: "Patient",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_AspNetUsers_ApplicationUserId",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patiennt");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_ApplicationUserId",
                table: "Patiennt",
                newName: "IX_Patiennt_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patiennt_AspNetUsers_ApplicationUserId",
                table: "Patiennt",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
