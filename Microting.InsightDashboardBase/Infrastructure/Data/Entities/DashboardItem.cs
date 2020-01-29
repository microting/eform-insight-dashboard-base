namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using System;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Enums;
    using Microsoft.EntityFrameworkCore;

    public class DashboardItem : BaseEntity
    {
        public int FirstQuestionId { get; set; } // questions.id
        public int? FilterQuestionId { get; set; } // questions.id
        public int? FilterAnswerId { get; set; } // options.id
        public DashboardPeriodUnits Period { get; set; }
        public DashboardChartTypes ChartType { get; set; }

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
                ChartType = ChartType,
                FilterAnswerId = FilterAnswerId,
                FilterQuestionId = FilterQuestionId,
                FirstQuestionId = FirstQuestionId,
                Period = Period,
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
            dashboardItem.ChartType = ChartType;
            dashboardItem.Period = Period;
            dashboardItem.FirstQuestionId = FirstQuestionId;
            dashboardItem.FilterQuestionId = FilterQuestionId;
            dashboardItem.FilterAnswerId = FilterAnswerId;

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

        private static DashboardItemVersion MapVersion(DashboardItem dashboardItem)
        {
            var dashboardItemVersion = new DashboardItemVersion
            {
                DashboardItemId = dashboardItem.Id,
                CreatedAt = dashboardItem.CreatedAt,
                UpdatedAt = dashboardItem.UpdatedAt,
                Version = dashboardItem.Version,
                WorkflowState = dashboardItem.WorkflowState,
                UpdatedByUserId = dashboardItem.UpdatedByUserId,
                CreatedByUserId = dashboardItem.CreatedByUserId,
                Position = dashboardItem.Position,
                ChartType = dashboardItem.ChartType,
                FilterAnswerId = dashboardItem.FilterAnswerId,
                FilterQuestionId = dashboardItem.FilterQuestionId,
                FirstQuestionId = dashboardItem.FirstQuestionId,
                Period = dashboardItem.Period,
            };

            return dashboardItemVersion;
        }
    }
}