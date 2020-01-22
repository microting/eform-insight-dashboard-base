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

        public async Task Clone(InsightDashboardPnDbContext dbContext)
        {
            var values = dbContext.Entry(this).CurrentValues.Clone();
            values[nameof(Dashboard.Id)] = 0;
            values[nameof(Dashboard.Version)] = 1;
            values[nameof(Dashboard.CreatedAt)] = DateTime.UtcNow;
            values[nameof(Dashboard.UpdatedAt)] = DateTime.UtcNow;
            values[nameof(Dashboard.UpdatedByUserId)] = UpdatedByUserId;
            values[nameof(Dashboard.CreatedByUserId)] = CreatedByUserId;
            values[nameof(Dashboard.WorkflowState)] = Constants.WorkflowStates.Created;


            var newDashboard = new Dashboard();
            dbContext.Entry(newDashboard).CurrentValues.SetValues(values);

            await dbContext.SaveChangesAsync();

            await dbContext.DashboardVersions.AddAsync(MapVersion(newDashboard));
            await dbContext.SaveChangesAsync();

            Id = newDashboard.Id;
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