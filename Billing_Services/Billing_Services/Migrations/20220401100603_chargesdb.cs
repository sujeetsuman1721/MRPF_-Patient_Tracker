using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing_Services.Migrations
{
    public partial class chargesdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationCharges = table.Column<int>(nullable: false),
                    LabTestCharges = table.Column<int>(nullable: false),
                    RoomCharges = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingServices");
        }
    }
}
