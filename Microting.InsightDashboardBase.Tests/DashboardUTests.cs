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

namespace Microting.InsightDashboardBase.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
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
            Random rnd = new Random();

            Dashboard dashboard = new Dashboard
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            // Act
            await dashboard.Create(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            DashboardVersion dbDashboardVersion = DbContext.DashboardVersions.AsNoTracking().First();
            List<DashboardVersion> dashboardVersions = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboard);
            Assert.NotNull(dbDashboardVersion);
            Assert.AreEqual(1, dashboards.Count);
            Assert.AreEqual(1, dashboardVersions.Count);

            Assert.AreEqual(dashboard.Id, dbDashboard.Id);
            Assert.AreEqual(dashboard.Version, dbDashboard.Version);
            Assert.AreEqual(dashboard.WorkflowState, dbDashboard.WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture), dbDashboard.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboard.CreatedByUserId, dbDashboard.CreatedByUserId);
            Assert.AreEqual(dashboard.UpdatedAt.ToString(), dbDashboard.UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dbDashboard.UpdatedByUserId);
        }

        [Test]
        public async Task Dashboard_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            Dashboard dashboard = new Dashboard
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            await dashboard.Create(DbContext);

            // Act
            var oldUpdatedAt = dashboard.UpdatedAt.GetValueOrDefault();

            await dashboard.Update(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            List<DashboardVersion> dashboardVersion = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboard);
            Assert.AreEqual(1, dashboards.Count);
            Assert.AreEqual(2, dashboardVersion.Count);

            Assert.AreEqual(dashboard.Id, dbDashboard.Id);
            Assert.AreEqual(dashboard.Version, dbDashboard.Version);
            Assert.AreEqual(dashboard.WorkflowState, dbDashboard.WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(CultureInfo.InvariantCulture), dbDashboard.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboard.CreatedByUserId, dbDashboard.CreatedByUserId);
            Assert.AreEqual(dashboard.UpdatedAt.ToString(), dbDashboard.UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dbDashboard.UpdatedByUserId);

            Assert.AreEqual(dashboard.Id, dashboardVersion[0].DashboardId);
            Assert.AreEqual(1, dashboardVersion[0].Version);
            Assert.AreEqual(dashboard.WorkflowState, dashboardVersion[0].WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(), dashboardVersion[0].CreatedAt.ToString());
            Assert.AreEqual(dashboard.CreatedByUserId, dashboardVersion[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), dashboardVersion[0].UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dashboardVersion[0].UpdatedByUserId);

            Assert.AreEqual(dashboard.Id, dashboardVersion[1].DashboardId);
            Assert.AreEqual(2, dashboardVersion[1].Version);
            Assert.AreEqual(dashboard.WorkflowState, dashboardVersion[1].WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(), dashboardVersion[1].CreatedAt.ToString());
            Assert.AreEqual(dashboard.CreatedByUserId, dashboardVersion[1].CreatedByUserId);
            Assert.AreEqual(dashboard.UpdatedAt.ToString(), dashboardVersion[1].UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dashboardVersion[1].UpdatedByUserId);
        }

        [Test]
        public async Task Dashboard_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            Dashboard dashboard = new Dashboard
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255)
            };

            await dashboard.Create(DbContext);

            // Act
            var oldUpdatedAt = dashboard.UpdatedAt.GetValueOrDefault();

            await dashboard.Delete(DbContext);

            // Assert
            Dashboard dbDashboard = DbContext.Dashboards.AsNoTracking().First();
            List<Dashboard> dashboards = DbContext.Dashboards.AsNoTracking().ToList();
            List<DashboardVersion> dashboardVersion = DbContext.DashboardVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboard);
            Assert.AreEqual(1, dashboards.Count);
            Assert.AreEqual(2, dashboardVersion.Count);

            Assert.AreEqual(dashboard.Id, dbDashboard.Id);
            Assert.AreEqual(dashboard.Version, dbDashboard.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDashboard.WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(), dbDashboard.CreatedAt.ToString());
            Assert.AreEqual(dashboard.CreatedByUserId, dbDashboard.CreatedByUserId);
            Assert.AreEqual(dashboard.UpdatedAt.ToString(), dbDashboard.UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dbDashboard.UpdatedByUserId);

            Assert.AreEqual(dashboard.Id, dashboardVersion[0].DashboardId);
            Assert.AreEqual(1, dashboardVersion[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, dashboardVersion[0].WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(), dashboardVersion[0].CreatedAt.ToString());
            Assert.AreEqual(dashboard.CreatedByUserId, dashboardVersion[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), dashboardVersion[0].UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dashboardVersion[0].UpdatedByUserId);

            Assert.AreEqual(dashboard.Id, dashboardVersion[1].DashboardId);
            Assert.AreEqual(2, dashboardVersion[1].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dashboardVersion[1].WorkflowState);
            Assert.AreEqual(dashboard.CreatedAt.ToString(), dashboardVersion[1].CreatedAt.ToString());
            Assert.AreEqual(dashboard.CreatedByUserId, dashboardVersion[1].CreatedByUserId);
            Assert.AreEqual(dashboard.UpdatedAt.ToString(), dashboardVersion[1].UpdatedAt.ToString());
            Assert.AreEqual(dashboard.UpdatedByUserId, dashboardVersion[1].UpdatedByUserId);
        }
    }
}