namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using System;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Microsoft.EntityFrameworkCore;

    public class DashboardItem : BaseEntity
    {
        public int Position { get; set; }
        public int DashboardId { get; set; }
        public virtual Dashboard Dashboard { get; set; }

        public async Task Save(InsightDashboardPnDbContext dbContext)
        {
            var dashboardItem = new DashboardItem
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                DashboardId = DashboardId,
                Position = Position,
            };

            await dbContext.DashboardItems.AddAsync(dashboardItem);
            await dbContext.SaveChangesAsync();

            await dbContext.DashboardItemVersions.AddAsync(MapVersion(dashboardItem));
            await dbContext.SaveChangesAsync();

            Id = dashboardItem.Id;
        }

        public async Task Update(InsightDashboardPnDbContext dbContext)
        {
            DashboardItem dashboardItem = await dbContext.DashboardItems.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItem == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboardItem.WorkflowState = WorkflowState;
            dashboardItem.UpdatedAt = UpdatedAt;
            dashboardItem.UpdatedByUserId = UpdatedByUserId;
            dashboardItem.Position = Position;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItem.UpdatedAt = DateTime.UtcNow;
                dashboardItem.Version += 1;

                dbContext.DashboardItemVersions.Add(MapVersion(dashboardItem));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(InsightDashboardPnDbContext dbContext)
        {
            DashboardItem dashboardItem = await dbContext.DashboardItems.FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardItem == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            dashboardItem.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                dashboardItem.UpdatedAt = DateTime.UtcNow;
                dashboardItem.Version += 1;

                dbContext.DashboardItemVersions.Add(MapVersion(dashboardItem));
                await dbContext.SaveChangesAsync();
            }
        }

        private static DashboardItemVersion MapVersion(DashboardItem dashboard)
        {
            var dashboardItemVersion = new DashboardItemVersion
            {
                DashboardId = dashboard.Id,
                CreatedAt = dashboard.CreatedAt,
                UpdatedAt = dashboard.UpdatedAt,
                Version = dashboard.Version,
                WorkflowState = dashboard.WorkflowState,
                UpdatedByUserId = dashboard.UpdatedByUserId,
                CreatedByUserId = dashboard.CreatedByUserId,
                Position = dashboard.Position,
            };

            return dashboardItemVersion;
        }
    }
}