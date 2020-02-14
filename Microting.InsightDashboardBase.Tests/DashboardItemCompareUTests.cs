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
    public class DashboardItemCompareUTests : DbTestFixture
    {
        [Test]
        public async Task DashboardItemCompare_Create_DoesCreate()
        {
            // Arrange
            var dashboardItemCompare = await DashboardHelpers.CreateDashboardItemCompare(DbContext);

            // Assert
            DashboardItemCompare dbDashboardItemCompare = DbContext.DashboardItemCompares.AsNoTracking().First();
            List<DashboardItemCompare> dashboardItemCompares = DbContext.DashboardItemCompares.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItemCompare);
            Assert.AreEqual(1, dashboardItemCompares.Count);

            Assert.AreEqual(dashboardItemCompare.Id, dbDashboardItemCompare.Id);
            Assert.AreEqual(1, dbDashboardItemCompare.Version);
            Assert.AreEqual(dashboardItemCompare.WorkflowState, dbDashboardItemCompare.WorkflowState);
            Assert.AreEqual(dashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture),
                dbDashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItemCompare.CreatedByUserId, dbDashboardItemCompare.CreatedByUserId);
            Assert.AreEqual(dashboardItemCompare.UpdatedAt.ToString(), dbDashboardItemCompare.UpdatedAt.ToString());
            Assert.AreEqual(dashboardItemCompare.UpdatedByUserId, dbDashboardItemCompare.UpdatedByUserId);
            Assert.AreEqual(dashboardItemCompare.Position, dbDashboardItemCompare.Position);
            Assert.AreEqual(dashboardItemCompare.LocationId, dbDashboardItemCompare.LocationId);
            Assert.AreEqual(dashboardItemCompare.TagId, dbDashboardItemCompare.TagId);
            Assert.AreEqual(dashboardItemCompare.DashboardItemId, dbDashboardItemCompare.DashboardItemId);
        }

        [Test]
        public async Task DashboardItemCompare_Delete_DoesDelete()
        {
            // Arrange
            var dashboardItemCompare = await DashboardHelpers.CreateDashboardItemCompare(DbContext);

            // Act
            await dashboardItemCompare.Delete(DbContext);

            // Assert
            DashboardItemCompare dbDashboardItemCompare = DbContext.DashboardItemCompares.AsNoTracking().First();
            List<DashboardItemCompare> dashboardItemCompareItems = DbContext.DashboardItemCompares.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItemCompare);
            Assert.AreEqual(1, dashboardItemCompareItems.Count);

            Assert.AreEqual(dashboardItemCompare.Id, dbDashboardItemCompare.Id);
            Assert.AreEqual(2, dbDashboardItemCompare.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDashboardItemCompare.WorkflowState);
            Assert.AreEqual(dashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture), dbDashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItemCompare.CreatedByUserId, dbDashboardItemCompare.CreatedByUserId);
            Assert.AreEqual(dashboardItemCompare.UpdatedByUserId, dbDashboardItemCompare.UpdatedByUserId);
            Assert.AreEqual(dashboardItemCompare.Position, dbDashboardItemCompare.Position);
        }
    }
}