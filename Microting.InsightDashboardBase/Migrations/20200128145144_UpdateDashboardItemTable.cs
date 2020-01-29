using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class UpdateDashboardItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DashboardItemVersions_Dashboards_DashboardId",
                table: "DashboardItemVersions");

            migrationBuilder.RenameColumn(
                name: "DashboardId",
                table: "DashboardItemVersions",
                newName: "DashboardItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DashboardItemVersions_DashboardId",
                table: "DashboardItemVersions",
                newName: "IX_DashboardItemVersions_DashboardItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardItemVersions_DashboardItems_DashboardItemId",
                table: "DashboardItemVersions",
                column: "DashboardItemId",
                principalTable: "DashboardItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DashboardItemVersions_DashboardItems_DashboardItemId",
                table: "DashboardItemVersions");

            migrationBuilder.RenameColumn(
                name: "DashboardItemId",
                table: "DashboardItemVersions",
                newName: "DashboardId");

            migrationBuilder.RenameIndex(
                name: "IX_DashboardItemVersions_DashboardItemId",
                table: "DashboardItemVersions",
                newName: "IX_DashboardItemVersions_DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_DashboardItemVersions_Dashboards_DashboardId",
                table: "DashboardItemVersions",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
