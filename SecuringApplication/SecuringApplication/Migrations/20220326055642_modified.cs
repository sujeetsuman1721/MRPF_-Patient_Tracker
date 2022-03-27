using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuringApplication.Migrations
{
    public partial class modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt");

            migrationBuilder.DropColumn(
                name: "PateintId",
                table: "Patiennt");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Patiennt",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patiennt");

            migrationBuilder.AddColumn<int>(
                name: "PateintId",
                table: "Patiennt",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patiennt",
                table: "Patiennt",
                column: "PateintId");
        }
    }
}
