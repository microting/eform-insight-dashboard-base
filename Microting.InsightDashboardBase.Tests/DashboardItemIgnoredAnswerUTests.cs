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
    public class DashboardItemIgnoredAnswerUTests : DbTestFixture
    {
        [Test]
        public async Task DashboardItemIgnoredAnswer_Create_DoesCreate()
        {
            // Arrange
            var dashboardItemIgnoredAnswer = await DashboardHelpers.CreateDashboardItemIgnoredAnswer(DbContext);

            // Assert
            DashboardItemIgnoredAnswer dbDashboardItemIgnoredAnswer =
                DbContext.DashboardItemIgnoredAnswers.AsNoTracking().First();
            List<DashboardItemIgnoredAnswer> dashboardItemIgnoredAnswers =
                DbContext.DashboardItemIgnoredAnswers.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItemIgnoredAnswer);
            Assert.AreEqual(1, dashboardItemIgnoredAnswers.Count);

            Assert.AreEqual(dashboardItemIgnoredAnswer.Id, dbDashboardItemIgnoredAnswer.Id);
            Assert.AreEqual(1, dbDashboardItemIgnoredAnswer.Version);
            Assert.AreEqual(dashboardItemIgnoredAnswer.WorkflowState, dbDashboardItemIgnoredAnswer.WorkflowState);
            Assert.AreEqual(dashboardItemIgnoredAnswer.CreatedAt.ToString(CultureInfo.InvariantCulture),
                dbDashboardItemIgnoredAnswer.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItemIgnoredAnswer.CreatedByUserId, dbDashboardItemIgnoredAnswer.CreatedByUserId);
            Assert.AreEqual(dashboardItemIgnoredAnswer.UpdatedAt.ToString(),
                dbDashboardItemIgnoredAnswer.UpdatedAt.ToString());
            Assert.AreEqual(dashboardItemIgnoredAnswer.UpdatedByUserId, dbDashboardItemIgnoredAnswer.UpdatedByUserId);
            Assert.AreEqual(dashboardItemIgnoredAnswer.AnswerId, dbDashboardItemIgnoredAnswer.AnswerId);
            Assert.AreEqual(dashboardItemIgnoredAnswer.DashboardItemId, dbDashboardItemIgnoredAnswer.DashboardItemId);
        }

        [Test]
        public async Task DashboardItemIgnoredAnswer_Delete_DoesDelete()
        {
            // Arrange
            var dashboardItemIgnoredAnswer = await DashboardHelpers.CreateDashboardItemIgnoredAnswer(DbContext);

            // Act
            await dashboardItemIgnoredAnswer.Delete(DbContext);

            // Assert
            DashboardItemIgnoredAnswer dbDashboardItemIgnoredAnswer = DbContext.DashboardItemIgnoredAnswers.AsNoTracking().First();
            List<DashboardItemIgnoredAnswer> dashboardItemIgnoredAnswers = DbContext.DashboardItemIgnoredAnswers.AsNoTracking().ToList();

            Assert.NotNull(dbDashboardItemIgnoredAnswer);
            Assert.AreEqual(1, dashboardItemIgnoredAnswers.Count);

            Assert.AreEqual(dashboardItemIgnoredAnswer.Id, dbDashboardItemIgnoredAnswer.Id);
            Assert.AreEqual(2, dbDashboardItemIgnoredAnswer.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, dbDashboardItemIgnoredAnswer.WorkflowState);
            Assert.AreEqual(dashboardItemIgnoredAnswer.CreatedAt.ToString(CultureInfo.InvariantCulture), dbDashboardItemIgnoredAnswer.CreatedAt.ToString(CultureInfo.InvariantCulture));
            Assert.AreEqual(dashboardItemIgnoredAnswer.CreatedByUserId, dbDashboardItemIgnoredAnswer.CreatedByUserId);
            Assert.AreEqual(dashboardItemIgnoredAnswer.UpdatedByUserId, dbDashboardItemIgnoredAnswer.UpdatedByUserId);
            Assert.AreEqual(dashboardItemIgnoredAnswer.AnswerId, dbDashboardItemIgnoredAnswer.AnswerId);
        }
    }
}