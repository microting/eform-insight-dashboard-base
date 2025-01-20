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

            Assert.That(dbDashboardItemCompare, Is.Not.Null);
            Assert.That(dashboardItemCompares.Count, Is.EqualTo(1));

            Assert.That(dbDashboardItemCompare.Id, Is.EqualTo(dashboardItemCompare.Id));
            Assert.That(dbDashboardItemCompare.Version, Is.EqualTo(1));
            Assert.That(dbDashboardItemCompare.WorkflowState, Is.EqualTo(dashboardItemCompare.WorkflowState));
            Assert.That(dbDashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture),
                Is.EqualTo(dashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboardItemCompare.CreatedByUserId, Is.EqualTo(dashboardItemCompare.CreatedByUserId));
            Assert.That(dbDashboardItemCompare.UpdatedAt.ToString(), Is.EqualTo(dashboardItemCompare.UpdatedAt.ToString()));
            Assert.That(dbDashboardItemCompare.UpdatedByUserId, Is.EqualTo(dashboardItemCompare.UpdatedByUserId));
            Assert.That(dbDashboardItemCompare.Position, Is.EqualTo(dashboardItemCompare.Position));
            Assert.That(dbDashboardItemCompare.LocationId, Is.EqualTo(dashboardItemCompare.LocationId));
            Assert.That(dbDashboardItemCompare.TagId, Is.EqualTo(dashboardItemCompare.TagId));
            Assert.That(dbDashboardItemCompare.DashboardItemId, Is.EqualTo(dashboardItemCompare.DashboardItemId));
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

            Assert.That(dbDashboardItemCompare, Is.Not.Null);
            Assert.That(dashboardItemCompareItems.Count, Is.EqualTo(1));

            Assert.That(dbDashboardItemCompare.Id, Is.EqualTo(dashboardItemCompare.Id));
            Assert.That(dbDashboardItemCompare.Version, Is.EqualTo(2));
            Assert.That(dbDashboardItemCompare.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbDashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture),
                Is.EqualTo(dashboardItemCompare.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboardItemCompare.CreatedByUserId, Is.EqualTo(dashboardItemCompare.CreatedByUserId));
            Assert.That(dbDashboardItemCompare.UpdatedByUserId, Is.EqualTo(dashboardItemCompare.UpdatedByUserId));
            Assert.That(dbDashboardItemCompare.Position, Is.EqualTo(dashboardItemCompare.Position));
        }
    }
}