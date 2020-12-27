/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

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

namespace Microting.InsightDashboardBase.Infrastructure.Data
{
    using eFormApi.BasePn.Abstractions;
    using eFormApi.BasePn.Infrastructure.Database.Entities;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class InsightDashboardPnDbContext : DbContext, IPluginDbContext
    {
        public InsightDashboardPnDbContext() { }

        public InsightDashboardPnDbContext(DbContextOptions<InsightDashboardPnDbContext> options) : base(options)
        {
        }

        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<DashboardVersion> DashboardVersions { get; set; }
        public DbSet<DashboardItem> DashboardItems { get; set; }
        public DbSet<DashboardItemVersion> DashboardItemVersions { get; set; }
        public DbSet<DashboardItemCompare> DashboardItemCompares { get; set; }
        public DbSet<DashboardItemCompareVersion> DashboardItemCompareVersions { get; set; }
        public DbSet<DashboardItemIgnoredAnswer> DashboardItemIgnoredAnswers { get; set; }
        public DbSet<DashboardItemIgnoredAnswerVersion> DashboardItemIgnoredAnswerVersions { get; set; }

        // default tables
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
        public DbSet<PluginPermission> PluginPermissions { get; set; }
        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dashboard>()
                .HasIndex(x => x.SurveyId);

            modelBuilder.Entity<Dashboard>()
                .HasIndex(x => x.LocationId);

            modelBuilder.Entity<Dashboard>()
                .HasIndex(x => x.TagId);

            modelBuilder.Entity<Dashboard>()
                .HasIndex(x => x.Name);

            modelBuilder.Entity<DashboardItem>()
                .HasIndex(x => x.FirstQuestionId);

            modelBuilder.Entity<DashboardItem>()
                .HasIndex(x => x.FilterQuestionId);

            modelBuilder.Entity<DashboardItem>()
                .HasIndex(x => x.FilterAnswerId);

            modelBuilder.Entity<DashboardItemCompare>()
                .HasIndex(x => x.LocationId);

            modelBuilder.Entity<DashboardItemCompare>()
                .HasIndex(x => x.TagId);

            modelBuilder.Entity<DashboardItemIgnoredAnswer>()
                .HasIndex(x => x.AnswerId);
        }
    }
}