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
        public int SurveyId { get; set; }

        public virtual List<DashboardLocation> DashboardLocation { get; set; }
            = new List<DashboardLocation>();
        public virtual List<DashboardReportTag> DashboardReportTags { get; set; }
            = new List<DashboardReportTag>();
        public virtual List<DashboardItem> DashboardItems { get; set; }
            = new List<DashboardItem>();

        public async Task Create(InsightDashboardPnDbContext dbContext)
        {
            Dashboard dashboard = new Dashboard
            {
                Name = Name,
                SurveyId = SurveyId,
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
            };

            return dashboardVersion;
        }
    }
}