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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Microsoft.EntityFrameworkCore;

    public class Dashboard : BaseEntity
    {
        [StringLength(250)]
        public string Name { get; set; }
        public int SurveyId { get; set; } // Question set
        public int? LocationId { get; set; } // Site id
        public int? TagId { get; set; } // Tag id

        public virtual List<DashboardItem> DashboardItems { get; set; }
            = new List<DashboardItem>();

        public async Task Create(InsightDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = new Dashboard
            {
                Name = Name,
                SurveyId = SurveyId,
                LocationId = LocationId,
                TagId = TagId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
            };

            await dbContext.Dashboards.AddAsync(dashboard);
            await dbContext.SaveChangesAsync();

            await dbContext.DashboardVersions.AddAsync(MapVersion(dashboard));
            await dbContext.SaveChangesAsync();

            Id = dashboard.Id;
        }

        public async Task Update(InsightDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = await dbContext.Dashboards.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboard == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboard.WorkflowState = WorkflowState;
            dashboard.UpdatedAt = UpdatedAt;
            dashboard.UpdatedByUserId = UpdatedByUserId;
            dashboard.Name = Name;
            dashboard.SurveyId = SurveyId;
            dashboard.LocationId = LocationId;
            dashboard.TagId = TagId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboard.UpdatedAt = DateTime.UtcNow;
                dashboard.Version += 1;

                dbContext.DashboardVersions.Add(MapVersion(dashboard));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(InsightDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = await dbContext.Dashboards.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboard == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboard.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboard.UpdatedAt = DateTime.UtcNow;
                dashboard.Version += 1;

                dbContext.DashboardVersions.Add(MapVersion(dashboard));
                await dbContext.SaveChangesAsync();
            }
        }

        private static DashboardVersion MapVersion(Dashboard dashboard)
        {
            var dashboardVersion = new DashboardVersion
            {
                DashboardId = dashboard.Id,
                CreatedAt = dashboard.CreatedAt,
                UpdatedAt = dashboard.UpdatedAt,
                Version = dashboard.Version,
                WorkflowState = dashboard.WorkflowState,
                UpdatedByUserId = dashboard.UpdatedByUserId,
                CreatedByUserId = dashboard.CreatedByUserId,
                Name = dashboard.Name,
                SurveyId = dashboard.SurveyId,
                LocationId = dashboard.LocationId,
                TagId = dashboard.TagId,
            };

            return dashboardVersion;
        }
    }
}