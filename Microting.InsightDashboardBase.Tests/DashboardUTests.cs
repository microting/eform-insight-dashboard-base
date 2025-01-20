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

namespace Microting.InsightDashboardBase.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using eForm.Infrastructure.Constants;
    using Helpers;
    using Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class DashboardUTests : DbTestFixture
    {
        [Test]
        public async Task Dashboard_Create_DoesCreate()
        {
            // Arrange
            var dashboard = DashboardHelpers.GetNewDashboard();

            // Act
            await dashboard.Create(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            DashboardVersion dbDashboardVersion = DbContext.DashboardVersions.AsNoTracking().First();
            List<DashboardVersion> dashboardVersions = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.That(dbDashboard, Is.Not.Null);
            Assert.That(dbDashboardVersion, Is.Not.Null);
            Assert.That(dashboards.Count, Is.EqualTo(1));
            Assert.That(dashboardVersions.Count, Is.EqualTo(1));

            Assert.That(dbDashboard.Id, Is.EqualTo(dashboard.Id));
            Assert.That(dbDashboard.Version, Is.EqualTo(1));
            Assert.That(dbDashboard.WorkflowState, Is.EqualTo(dashboard.WorkflowState));
            Assert.That(dbDashboard.CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboard.CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dbDashboard.UpdatedAt.ToString(), Is.EqualTo(dashboard.UpdatedAt.ToString()));
            Assert.That(dbDashboard.UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));
            Assert.That(dbDashboard.Name, Is.EqualTo(dashboard.Name));
            Assert.That(dbDashboard.SurveyId, Is.EqualTo(dashboard.SurveyId));
        }

        [Test]
        public async Task Dashboard_Update_DoesUpdate()
        {
            // Arrange
            var dashboard = DashboardHelpers.GetNewDashboard();

            await dashboard.Create(DbContext);

            // Act
            var oldUpdatedAt = dashboard.UpdatedAt.GetValueOrDefault();

            dashboard.Name += " - Updated";
            await dashboard.Update(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            List<DashboardVersion> dashboardVersion = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.That(dbDashboard, Is.Not.Null);
            Assert.That(dashboards.Count, Is.EqualTo(1));
            Assert.That(dashboardVersion.Count, Is.EqualTo(2));

            Assert.That(dbDashboard.Id, Is.EqualTo(dashboard.Id));
            Assert.That(dbDashboard.Version, Is.EqualTo(2));
            Assert.That(dbDashboard.WorkflowState, Is.EqualTo(dashboard.WorkflowState));
            Assert.That(dbDashboard.UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));
            Assert.That(dbDashboard.Name, Is.EqualTo(dashboard.Name));
            Assert.That(dbDashboard.LocationId, Is.EqualTo(dashboard.LocationId));
            Assert.That(dbDashboard.TagId, Is.EqualTo(dashboard.TagId));

            Assert.That(dashboardVersion[0].DashboardId, Is.EqualTo(dashboard.Id));
            Assert.That(dashboardVersion[0].Version, Is.EqualTo(1));
            Assert.That(dashboardVersion[0].WorkflowState, Is.EqualTo(dashboard.WorkflowState));
            Assert.That(dashboardVersion[0].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardVersion[0].CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dashboardVersion[0].Name, Is.EqualTo("Name"));
            Assert.That(dashboardVersion[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dashboardVersion[0].UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));

            Assert.That(dashboardVersion[1].DashboardId, Is.EqualTo(dashboard.Id));
            Assert.That(dashboardVersion[1].Version, Is.EqualTo(2));
            Assert.That(dashboardVersion[1].WorkflowState, Is.EqualTo(dashboard.WorkflowState));
            Assert.That(dashboardVersion[1].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardVersion[1].CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dashboardVersion[1].Name, Is.EqualTo("Name - Updated"));
            Assert.That(dashboardVersion[1].UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));
        }

        [Test]
        public async Task Dashboard_Delete_DoesDelete()
        {
            // Arrange
            var dashboard = DashboardHelpers.GetNewDashboard();

            await dashboard.Create(DbContext);

            // Act
            var oldUpdatedAt = dashboard.UpdatedAt.GetValueOrDefault();

            await dashboard.Delete(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            List<DashboardVersion> dashboardVersion = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.That(dbDashboard, Is.Not.Null);
            Assert.That(dashboards.Count, Is.EqualTo(1));
            Assert.That(dashboardVersion.Count, Is.EqualTo(2));

            Assert.That(dbDashboard.Id, Is.EqualTo(dashboard.Id));
            Assert.That(dbDashboard.Version, Is.EqualTo(2));
            Assert.That(dbDashboard.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbDashboard.CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboard.CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dbDashboard.UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));

            Assert.That(dashboardVersion[0].DashboardId, Is.EqualTo(dashboard.Id));
            Assert.That(dashboardVersion[0].Version, Is.EqualTo(1));
            Assert.That(dashboardVersion[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dashboardVersion[0].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardVersion[0].CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dashboardVersion[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dashboardVersion[0].UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));

            Assert.That(dashboardVersion[1].DashboardId, Is.EqualTo(dashboard.Id));
            Assert.That(dashboardVersion[1].Version, Is.EqualTo(2));
            Assert.That(dashboardVersion[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dashboardVersion[1].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardVersion[1].CreatedByUserId, Is.EqualTo(dashboard.CreatedByUserId));
            Assert.That(dashboardVersion[1].UpdatedByUserId, Is.EqualTo(dashboard.UpdatedByUserId));
        }
    }
}