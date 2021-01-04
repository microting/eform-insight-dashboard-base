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

namespace Microting.InsightDashboardBase.Tests.Helpers
{
    using System;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using Infrastructure.Data;
    using Infrastructure.Data.Entities;
    using Infrastructure.Enums;

    public static class DashboardHelpers
    {
        public static Dashboard GetNewDashboard()
        {
            Random rnd = new Random();

            Dashboard dashboard = new Dashboard
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                WorkflowState = Constants.WorkflowStates.Created,
                Name = "Name",
                SurveyId = 1,
            };

            return dashboard;
        }

        public static DashboardItem GetNewDashboardItem(int dashboardId)
        {
            Random rnd = new Random();

            DashboardItem dashboardItem = new DashboardItem
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                WorkflowState = Constants.WorkflowStates.Created,
                Position = 1,
                CompareEnabled = false,
                CalculateAverage = false,
                DashboardId = dashboardId,
                ChartType = DashboardChartTypes.HorizontalBar,
                FilterAnswerId = 1,
                Period = DashboardPeriodUnits.Month,
                FilterQuestionId = 1,
                FirstQuestionId = 1,
            };

            return dashboardItem;
        }

        public static async Task<DashboardItem> CreateDashboardItem(InsightDashboardPnDbContext dbContext)
        {
            // Dashboard
            var dashboard = GetNewDashboard();
            await dashboard.Create(dbContext);

            // Dashboard item
            var dashboardItem = GetNewDashboardItem(dashboard.Id);
            await dashboardItem.Create(dbContext);

            return dashboardItem;
        }

        public static async Task<DashboardItemCompare> CreateDashboardItemCompare(InsightDashboardPnDbContext dbContext)
        {
            var dashboardItem = await CreateDashboardItem(dbContext);

            Random rnd = new Random();

            DashboardItemCompare dashboardItemCompare = new DashboardItemCompare
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                WorkflowState = Constants.WorkflowStates.Created,
                Position = 1,
                TagId = 1,
                LocationId = 1,
                DashboardItemId = dashboardItem.Id,
            };

            await dashboardItemCompare.Create(dbContext);;

            return dashboardItemCompare;
        }

        public static async Task<DashboardItemIgnoredAnswer> CreateDashboardItemIgnoredAnswer(InsightDashboardPnDbContext dbContext)
        {
            var dashboardItem = await CreateDashboardItem(dbContext);

            Random rnd = new Random();

            DashboardItemIgnoredAnswer dashboardItemIgnoredAnswer = new DashboardItemIgnoredAnswer
            {
                UpdatedByUserId = rnd.Next(1, 255),
                CreatedByUserId = rnd.Next(1, 255),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                WorkflowState = Constants.WorkflowStates.Created,
                DashboardItemId = dashboardItem.Id,
                AnswerId = 1,
            };

            await dashboardItemIgnoredAnswer.Create(dbContext); ;

            return dashboardItemIgnoredAnswer;
        }
    }
}
