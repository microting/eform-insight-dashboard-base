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

namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using System;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Microsoft.EntityFrameworkCore;

    public class DashboardItemIgnoredAnswer : BaseEntity
    {
        public int AnswerId { get; set; }
        public int DashboardItemId { get; set; }
        public virtual DashboardItem DashboardItem { get; set; }

        public async Task Save(InsightDashboardPnDbContext dbContext)
        {
            var dashboardReportTag = new DashboardItemIgnoredAnswer
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                DashboardItemId = DashboardItemId,
                AnswerId = AnswerId,
            };

            await dbContext.DashboardItemIgnoredAnswers.AddAsync(dashboardReportTag);
            await dbContext.SaveChangesAsync();

            Id = dashboardReportTag.Id;
        }

        public async Task Delete(InsightDashboardPnDbContext dbContext)
        {
            var dashboardReportTag = await dbContext.DashboardItemIgnoredAnswers
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardReportTag == null)
            {
                throw new NullReferenceException($"Could not find ignoredAnswer with id: {Id}");
            }

            dashboardReportTag.WorkflowState = Constants.WorkflowStates.Removed;
            dashboardReportTag.UpdatedAt = DateTime.UtcNow;
            dashboardReportTag.Version += 1;
            dashboardReportTag.AnswerId = AnswerId;

            dbContext.DashboardItemIgnoredAnswers.Update(dashboardReportTag);
            await dbContext.SaveChangesAsync();
        }
    }
}