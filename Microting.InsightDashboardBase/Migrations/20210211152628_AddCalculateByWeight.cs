using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class AddCalculateByWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CalculateByWeight",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CalculateByWeight",
                table: "DashboardItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculateByWeight",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "CalculateByWeight",
                table: "DashboardItems");
        }
    }
}
