using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class AddDashboardFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "DashboardVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "DashboardVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Dashboards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Dashboards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChartType",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstQuestionId",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChartType",
                table: "DashboardItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstQuestionId",
                table: "DashboardItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "DashboardItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_LocationId",
                table: "Dashboards",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_Name",
                table: "Dashboards",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_TagId",
                table: "Dashboards",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItems_FilterAnswerId",
                table: "DashboardItems",
                column: "FilterAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItems_FilterQuestionId",
                table: "DashboardItems",
                column: "FilterQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItems_FirstQuestionId",
                table: "DashboardItems",
                column: "FirstQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dashboards_LocationId",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_Name",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_TagId",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_DashboardItems_FilterAnswerId",
                table: "DashboardItems");

            migrationBuilder.DropIndex(
                name: "IX_DashboardItems_FilterQuestionId",
                table: "DashboardItems");

            migrationBuilder.DropIndex(
                name: "IX_DashboardItems_FirstQuestionId",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "DashboardVersions");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "DashboardVersions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "ChartType",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "FilterAnswerId",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "FilterQuestionId",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "FirstQuestionId",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "ChartType",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "FilterAnswerId",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "FilterQuestionId",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "FirstQuestionId",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "DashboardItems");
        }
    }
}
