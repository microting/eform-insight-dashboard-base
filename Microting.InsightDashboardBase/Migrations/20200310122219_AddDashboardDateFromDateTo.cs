using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class AddDashboardDateFromDateTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "DashboardVersions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "DashboardVersions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Today",
                table: "DashboardVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Dashboards",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Dashboards",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Today",
                table: "Dashboards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "DashboardVersions");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "DashboardVersions");

            migrationBuilder.DropColumn(
                name: "Today",
                table: "DashboardVersions");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "Today",
                table: "Dashboards");
        }
    }
}
