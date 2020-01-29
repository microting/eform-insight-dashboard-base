using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class UpdateNullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItemVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItemVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItems",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItemVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItemVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilterQuestionId",
                table: "DashboardItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilterAnswerId",
                table: "DashboardItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
