using Microsoft.EntityFrameworkCore.Migrations;

namespace SecuringApplication.Migrations
{
    public partial class thisisfirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "RegistratioStatus",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistratioStatus",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ContactNumber",
                table: "AspNetUsers",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
