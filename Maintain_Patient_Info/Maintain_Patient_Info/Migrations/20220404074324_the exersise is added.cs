using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintain_Patient_Info.Migrations
{
    public partial class theexersiseisadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseOrDiet",
                table: "PatientsRegistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseOrDiet",
                table: "PatientsRegistory");
        }
    }
}
