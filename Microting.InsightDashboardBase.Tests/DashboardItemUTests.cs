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

            Assert.That(dbDashboardItem, Is.Not.Null);
            Assert.That(dbDashboardItemVersion, Is.Not.Null);
            Assert.That(dashboardItems.Count, Is.EqualTo(1));
            Assert.That(dashboardItemVersions.Count, Is.EqualTo(1));

            Assert.That(dbDashboardItem.Id, Is.EqualTo(dashboardItem.Id));
            Assert.That(dbDashboardItem.Version, Is.EqualTo(1));
            Assert.That(dbDashboardItem.WorkflowState, Is.EqualTo(dashboardItem.WorkflowState));
            Assert.That(dbDashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboardItem.CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dbDashboardItem.UpdatedAt.ToString(), Is.EqualTo(dashboardItem.UpdatedAt.ToString()));
            Assert.That(dbDashboardItem.UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));
            Assert.That(dbDashboardItem.Position, Is.EqualTo(dashboardItem.Position));
            Assert.That(dbDashboardItem.CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dbDashboardItem.ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dbDashboardItem.CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dbDashboardItem.FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dbDashboardItem.FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dbDashboardItem.Period, Is.EqualTo(dashboardItem.Period));
        }

        [Test]
        public async Task DashboardItem_Update_DoesUpdate()
        {
            // Arrange
            var dashboardItem = await DashboardHelpers.CreateDashboardItem(DbContext);

            // Act
            var oldUpdatedAt = dashboardItem.UpdatedAt.GetValueOrDefault();

            dashboardItem.Position = 0;
            await dashboardItem.Update(DbContext);

            // Assert
            DashboardItem dbDashboardItem = DbContext.DashboardItems.AsNoTracking().First();
            List<DashboardItem> dashboardItems = DbContext.DashboardItems.AsNoTracking().ToList();
            List<DashboardItemVersion> dashboardItemVersions = DbContext.DashboardItemVersions.AsNoTracking().ToList();

            Assert.That(dbDashboardItem, Is.Not.Null);
            Assert.That(dashboardItems.Count, Is.EqualTo(1));
            Assert.That(dashboardItemVersions.Count, Is.EqualTo(2));

            Assert.That(dbDashboardItem.Id, Is.EqualTo(dashboardItem.Id));
            Assert.That(dbDashboardItem.Version, Is.EqualTo(2));
            Assert.That(dbDashboardItem.WorkflowState, Is.EqualTo(dashboardItem.WorkflowState));
            Assert.That(dbDashboardItem.UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dbDashboardItem.Position, Is.EqualTo(0));
            Assert.That(dbDashboardItem.CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dbDashboardItem.ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dbDashboardItem.CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dbDashboardItem.FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dbDashboardItem.FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dbDashboardItem.Period, Is.EqualTo(dashboardItem.Period));

            Assert.That(dashboardItemVersions[0].DashboardItemId, Is.EqualTo(dashboardItem.Id));
            Assert.That(dashboardItemVersions[0].Version, Is.EqualTo(1));
            Assert.That(dashboardItemVersions[0].WorkflowState, Is.EqualTo(dashboardItem.WorkflowState));
            Assert.That(dashboardItemVersions[0].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardItemVersions[0].CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dashboardItemVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dashboardItemVersions[0].UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dashboardItemVersions[0].Position, Is.EqualTo(1));
            Assert.That(dashboardItemVersions[0].CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dashboardItemVersions[0].ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dashboardItemVersions[0].CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dashboardItemVersions[0].FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dashboardItemVersions[0].FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dashboardItemVersions[0].Period, Is.EqualTo(dashboardItem.Period));


            Assert.That(dashboardItemVersions[1].DashboardItemId, Is.EqualTo(dashboardItem.Id));
            Assert.That(dashboardItemVersions[1].Version, Is.EqualTo(2));
            Assert.That(dashboardItemVersions[1].WorkflowState, Is.EqualTo(dashboardItem.WorkflowState));
            Assert.That(dashboardItemVersions[1].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardItemVersions[1].CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dashboardItemVersions[1].UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dashboardItemVersions[1].Position, Is.EqualTo(0));
            Assert.That(dashboardItemVersions[1].CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dashboardItemVersions[1].ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dashboardItemVersions[1].CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dashboardItemVersions[1].FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dashboardItemVersions[1].FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dashboardItemVersions[1].Period, Is.EqualTo(dashboardItem.Period));
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

            Assert.That(dbDashboardItem, Is.Not.Null);
            Assert.That(dashboardItems.Count, Is.EqualTo(1));
            Assert.That(dashboardItemVersions.Count, Is.EqualTo(2));

            Assert.That(dbDashboardItem.Id, Is.EqualTo(dashboardItem.Id));
            Assert.That(dbDashboardItem.Version, Is.EqualTo(2));
            Assert.That(dbDashboardItem.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dbDashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dbDashboardItem.CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dbDashboardItem.UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dashboardItemVersions[0].DashboardItemId, Is.EqualTo(dashboardItem.Id));
            Assert.That(dashboardItemVersions[0].Version, Is.EqualTo(1));
            Assert.That(dashboardItemVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(dashboardItemVersions[0].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardItemVersions[0].CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dashboardItemVersions[0].UpdatedAt.ToString(), Is.EqualTo(oldUpdatedAt.ToString()));
            Assert.That(dashboardItemVersions[0].UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dashboardItemVersions[0].Position, Is.EqualTo(dashboardItem.Position));
            Assert.That(dashboardItemVersions[0].CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dashboardItemVersions[0].ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dashboardItemVersions[0].CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dashboardItemVersions[0].FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dashboardItemVersions[0].FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dashboardItemVersions[0].Period, Is.EqualTo(dashboardItem.Period));

            Assert.That(dashboardItemVersions[1].DashboardItemId, Is.EqualTo(dashboardItem.Id));
            Assert.That(dashboardItemVersions[1].Version, Is.EqualTo(2));
            Assert.That(dashboardItemVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(dashboardItemVersions[1].CreatedAt.ToString(CultureInfo.InvariantCulture), Is.EqualTo(dashboardItem.CreatedAt.ToString(CultureInfo.InvariantCulture)));
            Assert.That(dashboardItemVersions[1].CreatedByUserId, Is.EqualTo(dashboardItem.CreatedByUserId));
            Assert.That(dashboardItemVersions[1].UpdatedByUserId, Is.EqualTo(dashboardItem.UpdatedByUserId));

            Assert.That(dashboardItemVersions[1].Position, Is.EqualTo(dashboardItem.Position));
            Assert.That(dashboardItemVersions[1].CalculateAverage, Is.EqualTo(dashboardItem.CalculateAverage));
            Assert.That(dashboardItemVersions[1].ChartType, Is.EqualTo(dashboardItem.ChartType));
            Assert.That(dashboardItemVersions[1].CompareEnabled, Is.EqualTo(dashboardItem.CompareEnabled));
            Assert.That(dashboardItemVersions[1].FilterAnswerId, Is.EqualTo(dashboardItem.FilterAnswerId));
            Assert.That(dashboardItemVersions[1].FilterQuestionId, Is.EqualTo(dashboardItem.FilterQuestionId));
            Assert.That(dashboardItemVersions[1].Period, Is.EqualTo(dashboardItem.Period));
        }
    }
}