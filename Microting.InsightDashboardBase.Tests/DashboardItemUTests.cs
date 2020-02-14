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
    public class DashboardItemUTests : DbTestFixture
    {
        [Test]
        public async Task DashboardItem_Create_DoesCreate()
        {
            // Arrange
            var dashboardItem = await DashboardHelpers.CreateDashboardItem(DbContext);

            // Assert
            DashboardItem dbDashboardItem = DbContext.DashboardItems.AsNoTracking().First();
            List<DashboardItem> dashboardItems = DbContext.DashboardItems.AsNoTracking().ToList();
            DashboardItemVersion dbDashboardItemVersion = DbContext.DashboardItemVersions.AsNoTracking().First();
            List<DashboardItemVersion> dashboardItemVersions = DbContext.DashboardItemVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItem);
            Assert.NotNull(dbDashboardItemVersion);
            Assert.AreEqual(1, dashboardItems.Count);
            Assert.AreEqual(1, dashboardItemVersions.Count);

            Assert.AreEqual(dashboardItem.Id, dbDashboardItem.Id);
            Assert.AreEqual(1, dbDashboardItem.Version);
            Assert.AreEqual(dashboardItem.WorkflowState, dbDashboardItem.WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture),
                dbDashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dbDashboardItem.CreatedByUserId);
            Assert.AreEqual(dashboardItem.UpdatedAt.ToString(), dbDashboardItem.UpdatedAt.ToString());
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dbDashboardItem.UpdatedByUserId);
            Assert.AreEqual(dashboardItem.Position, dbDashboardItem.Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dbDashboardItem.CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dbDashboardItem.ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dbDashboardItem.CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dbDashboardItem.FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dbDashboardItem.FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dbDashboardItem.Period);
        }

        [Test]
        public async Task DashboardItem_Update_DoesUpdate()
        {
            // Arrange
            var dashboardItem = await DashboardHelpers.CreateDashboardItem(DbContext);

            // Act
            var oldUpdatedAt = dashboardItem.UpdatedAt.GetValueOrDefault();

            await dashboardItem.Update(DbContext);

            // Assert
            DashboardItem dbDashboardItem = DbContext.DashboardItems.AsNoTracking().First();
            List<DashboardItem> dashboardItems = DbContext.DashboardItems.AsNoTracking().ToList();
            List<DashboardItemVersion> dashboardItemVersions = DbContext.DashboardItemVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItem);
            Assert.AreEqual(1, dashboardItems.Count);
            Assert.AreEqual(2, dashboardItemVersions.Count);

            Assert.AreEqual(dashboardItem.Id, dbDashboardItem.Id);
            Assert.AreEqual(2, dbDashboardItem.Version);
            Assert.AreEqual(dashboardItem.WorkflowState, dbDashboardItem.WorkflowState);
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dbDashboardItem.UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Position, dbDashboardItem.Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dbDashboardItem.CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dbDashboardItem.ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dbDashboardItem.CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dbDashboardItem.FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dbDashboardItem.FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dbDashboardItem.Period);

            Assert.AreEqual(dashboardItem.Id, dashboardItemVersions[0].DashboardItemId);
            Assert.AreEqual(1, dashboardItemVersions[0].Version);
            Assert.AreEqual(dashboardItem.WorkflowState, dashboardItemVersions[0].WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), dashboardItemVersions[0].CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dashboardItemVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), dashboardItemVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dashboardItemVersions[0].UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Position, dashboardItemVersions[0].Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dashboardItemVersions[0].CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dashboardItemVersions[0].ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dashboardItemVersions[0].CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dashboardItemVersions[0].FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dashboardItemVersions[0].FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dashboardItemVersions[0].Period);


            Assert.AreEqual(dashboardItem.Id, dashboardItemVersions[1].DashboardItemId);
            Assert.AreEqual(2, dashboardItemVersions[1].Version);
            Assert.AreEqual(dashboardItem.WorkflowState, dashboardItemVersions[1].WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), dashboardItemVersions[1].CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dashboardItemVersions[1].CreatedByUserId);
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dashboardItemVersions[1].UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Position, dashboardItemVersions[1].Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dashboardItemVersions[1].CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dashboardItemVersions[1].ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dashboardItemVersions[1].CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dashboardItemVersions[1].FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dashboardItemVersions[1].FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dashboardItemVersions[1].Period);
        }

        [Test]
        public async Task DashboardItem_Delete_DoesDelete()
        {
            // Arrange
            var dashboardItem = await DashboardHelpers.CreateDashboardItem(DbContext);

            // Act
            var oldUpdatedAt = dashboardItem.UpdatedAt.GetValueOrDefault();

            await dashboardItem.Delete(DbContext);

            // Assert
            DashboardItem dbDashboardItem = DbContext.DashboardItems.AsNoTracking().First();
            List<DashboardItem> dashboardItems = DbContext.DashboardItems.AsNoTracking().ToList();
            List<DashboardItemVersion> dashboardItemVersions = DbContext.DashboardItemVersions.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItem);
            Assert.AreEqual(1, dashboardItems.Count);
            Assert.AreEqual(2, dashboardItemVersions.Count);

            Assert.AreEqual(dashboardItem.Id, dbDashboardItem.Id);
            Assert.AreEqual(2, dbDashboardItem.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDashboardItem.WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), dbDashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dbDashboardItem.CreatedByUserId);
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dbDashboardItem.UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Id, dashboardItemVersions[0].DashboardItemId);
            Assert.AreEqual(1, dashboardItemVersions[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, dashboardItemVersions[0].WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), dashboardItemVersions[0].CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dashboardItemVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), dashboardItemVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dashboardItemVersions[0].UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Position, dashboardItemVersions[0].Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dashboardItemVersions[0].CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dashboardItemVersions[0].ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dashboardItemVersions[0].CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dashboardItemVersions[0].FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dashboardItemVersions[0].FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dashboardItemVersions[0].Period);

            Assert.AreEqual(dashboardItem.Id, dashboardItemVersions[1].DashboardItemId);
            Assert.AreEqual(2, dashboardItemVersions[1].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dashboardItemVersions[1].WorkflowState);
            Assert.AreEqual(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), dashboardItemVersions[1].CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItem.CreatedByUserId, dashboardItemVersions[1].CreatedByUserId);
            Assert.AreEqual(dashboardItem.UpdatedByUserId, dashboardItemVersions[1].UpdatedByUserId);

            Assert.AreEqual(dashboardItem.Position, dashboardItemVersions[1].Position);
            Assert.AreEqual(dashboardItem.CalculateAverage, dashboardItemVersions[1].CalculateAverage);
            Assert.AreEqual(dashboardItem.ChartType, dashboardItemVersions[1].ChartType);
            Assert.AreEqual(dashboardItem.CompareEnabled, dashboardItemVersions[1].CompareEnabled);
            Assert.AreEqual(dashboardItem.FilterAnswerId, dashboardItemVersions[1].FilterAnswerId);
            Assert.AreEqual(dashboardItem.FilterQuestionId, dashboardItemVersions[1].FilterQuestionId);
            Assert.AreEqual(dashboardItem.Period, dashboardItemVersions[1].Period);
        }
    }
}