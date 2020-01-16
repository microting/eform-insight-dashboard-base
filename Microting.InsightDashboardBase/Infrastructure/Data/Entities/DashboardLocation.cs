namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using System;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Microsoft.EntityFrameworkCore;

    public class DashboardLocation : BaseEntity
    {
        public int LocationId { get; set; } // Sites
        public int DashboardId { get; set; }
        public virtual Dashboard Dashboard { get; set; }

        public async Task Save(InsightDashboardPnDbContext dbContext)
        {
            var dashboardLocation = new DashboardLocation
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                UpdatedByUserId = UpdatedByUserId,
                CreatedByUserId = CreatedByUserId,
                DashboardId = DashboardId,
                LocationId = LocationId,
            };

            await dbContext.DashboardLocations.AddAsync(dashboardLocation);
            await dbContext.SaveChangesAsync();

            Id = dashboardLocation.Id;
        }

        public async Task Delete(InsightDashboardPnDbContext dbContext)
        {
            var dashboardLocation = await dbContext.DashboardLocations
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (dashboardLocation == null)
            {
                throw new NullReferenceException($"Could not find dashboardLocation with id: {Id}");
            }

            dashboardLocation.WorkflowState = Constants.WorkflowStates.Removed;
            dashboardLocation.UpdatedAt = DateTime.UtcNow;
            dashboardLocation.Version += 1;
            dashboardLocation.LocationId = LocationId;

            dbContext.DashboardLocations.Update(dashboardLocation);
            await dbContext.SaveChangesAsync();
        }
    }
}