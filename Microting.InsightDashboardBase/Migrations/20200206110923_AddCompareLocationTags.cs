/*
The MIT License (MIT)

Copyright (c) 2007 - 2021 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.InsightDashboardBase.Migrations
{
    public partial class AddCompareLocationTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            migrationBuilder.DropTable(
                name: "DashboardLocations");

            migrationBuilder.DropTable(
                name: "DashboardReportTags");

            migrationBuilder.AddColumn<bool>(
                name: "CalculateAverage",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompareEnabled",
                table: "DashboardItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CalculateAverage",
                table: "DashboardItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CompareEnabled",
                table: "DashboardItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DashboardItemCompares",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    LocationId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(),
                    DashboardItemId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItemCompares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardItemCompares_DashboardItems_DashboardItemId",
                        column: x => x.DashboardItemId,
                        principalTable: "DashboardItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardItemIgnoredAnswers",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AnswerId = table.Column<int>(),
                    DashboardItemId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItemIgnoredAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardItemIgnoredAnswers_DashboardItems_DashboardItemId",
                        column: x => x.DashboardItemId,
                        principalTable: "DashboardItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemCompares_DashboardItemId",
                table: "DashboardItemCompares",
                column: "DashboardItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemCompares_LocationId",
                table: "DashboardItemCompares",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemCompares_TagId",
                table: "DashboardItemCompares",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemIgnoredAnswers_AnswerId",
                table: "DashboardItemIgnoredAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemIgnoredAnswers_DashboardItemId",
                table: "DashboardItemIgnoredAnswers",
                column: "DashboardItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.DropTable(
                name: "DashboardItemCompares");

            migrationBuilder.DropTable(
                name: "DashboardItemIgnoredAnswers");

            migrationBuilder.DropColumn(
                name: "CalculateAverage",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "CompareEnabled",
                table: "DashboardItemVersions");

            migrationBuilder.DropColumn(
                name: "CalculateAverage",
                table: "DashboardItems");

            migrationBuilder.DropColumn(
                name: "CompareEnabled",
                table: "DashboardItems");

            migrationBuilder.CreateTable(
                name: "DashboardLocations",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    CreatedByUserId = table.Column<int>(),
                    DashboardId = table.Column<int>(),
                    LocationId = table.Column<int>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardLocations_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardReportTags",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(autoIdGenStrategy, autoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    CreatedByUserId = table.Column<int>(),
                    DashboardId = table.Column<int>(),
                    ReportTagId = table.Column<int>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardReportTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardReportTags_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardLocations_DashboardId",
                table: "DashboardLocations",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardLocations_LocationId",
                table: "DashboardLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardReportTags_DashboardId",
                table: "DashboardReportTags",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardReportTags_ReportTagId",
                table: "DashboardReportTags",
                column: "ReportTagId");
        }
    }
}
