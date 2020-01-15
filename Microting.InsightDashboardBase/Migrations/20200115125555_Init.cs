using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider
            var appointmentAutoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object appointmentAutoIdGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                appointmentAutoIdGenStrategy = "MySql:ValueGenerationStrategy";
                appointmentAutoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginPermissions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    PermissionName = table.Column<string>(nullable: true),
                    ClaimName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginGroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    GroupId = table.Column<int>(),
                    PermissionId = table.Column<int>(),
                    IsEnabled = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginGroupPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissions_PluginPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PluginPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PluginGroupPermissionVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    GroupId = table.Column<int>(),
                    PermissionId = table.Column<int>(),
                    IsEnabled = table.Column<bool>(),
                    PluginGroupPermissionId = table.Column<int>(),
                    FK_PluginGroupPermissionVersions_PluginGroupPermissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginGroupPermissionVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissionVersions_PluginGroupPermissions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                        column: x => x.FK_PluginGroupPermissionVersions_PluginGroupPermissionId,
                        principalTable: "PluginGroupPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PluginGroupPermissionVersions_PluginPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PluginPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissions_PermissionId",
                table: "PluginGroupPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_FK_PluginGroupPermissionVersions_PluginGroupPermissionId",
                table: "PluginGroupPermissionVersions",
                column: "FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PluginGroupPermissionVersions_PermissionId",
                table: "PluginGroupPermissionVersions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "PluginGroupPermissionVersions");

            migrationBuilder.DropTable(
                name: "PluginGroupPermissions");

            migrationBuilder.DropTable(
                name: "PluginPermissions");
        }
    }
}
