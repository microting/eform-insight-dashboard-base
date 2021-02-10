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
