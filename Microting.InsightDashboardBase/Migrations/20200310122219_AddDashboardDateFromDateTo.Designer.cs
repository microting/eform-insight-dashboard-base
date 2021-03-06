﻿// <auto-generated />
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.InsightDashboardBase.Infrastructure.Data;

namespace Microting.InsightDashboardBase.Migrations
{
    [DbContext(typeof(InsightDashboardPnDbContext))]
    [Migration("20200310122219_AddDashboardDateFromDateTo")]
    partial class AddDashboardDateFromDateTo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.Dashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime?>("DateFrom");

                    b.Property<DateTime?>("DateTo");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<int>("SurveyId");

                    b.Property<int?>("TagId");

                    b.Property<bool>("Today");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("Name");

                    b.HasIndex("SurveyId");

                    b.HasIndex("TagId");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CalculateAverage");

                    b.Property<int>("ChartType");

                    b.Property<bool>("CompareEnabled");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DashboardId");

                    b.Property<int?>("FilterAnswerId");

                    b.Property<int?>("FilterQuestionId");

                    b.Property<int>("FirstQuestionId");

                    b.Property<int>("Period");

                    b.Property<int>("Position");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.HasIndex("FilterAnswerId");

                    b.HasIndex("FilterQuestionId");

                    b.HasIndex("FirstQuestionId");

                    b.ToTable("DashboardItems");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemCompare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DashboardItemId");

                    b.Property<int?>("LocationId");

                    b.Property<int>("Position");

                    b.Property<int?>("TagId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardItemId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TagId");

                    b.ToTable("DashboardItemCompares");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemIgnoredAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DashboardItemId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("DashboardItemId");

                    b.ToTable("DashboardItemIgnoredAnswers");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CalculateAverage");

                    b.Property<int>("ChartType");

                    b.Property<bool>("CompareEnabled");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DashboardItemId");

                    b.Property<int?>("FilterAnswerId");

                    b.Property<int?>("FilterQuestionId");

                    b.Property<int>("FirstQuestionId");

                    b.Property<int>("Period");

                    b.Property<int>("Position");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardItemId");

                    b.ToTable("DashboardItemVersions");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime?>("DateFrom");

                    b.Property<DateTime?>("DateTo");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<int>("SurveyId");

                    b.Property<int?>("TagId");

                    b.Property<bool>("Today");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.ToTable("DashboardVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("PluginGroupPermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("PermissionName");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginPermissions");
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItem", b =>
                {
                    b.HasOne("Microting.InsightDashboardBase.Infrastructure.Data.Entities.Dashboard", "Dashboard")
                        .WithMany("DashboardItems")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemCompare", b =>
                {
                    b.HasOne("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany("CompareLocationsTags")
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemIgnoredAnswer", b =>
                {
                    b.HasOne("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany("IgnoredAnswerValues")
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItemVersion", b =>
                {
                    b.HasOne("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany()
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InsightDashboardBase.Infrastructure.Data.Entities.DashboardVersion", b =>
                {
                    b.HasOne("Microting.InsightDashboardBase.Infrastructure.Data.Entities.Dashboard", "Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", "PluginGroupPermission")
                        .WithMany()
                        .HasForeignKey("FK_PluginGroupPermissionVersions_PluginGroupPermissionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
