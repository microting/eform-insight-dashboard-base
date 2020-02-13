namespace Microting.InsightDashboardBase.Tests.Helpers
{
    using System;
    using eForm.Infrastructure.Constants;
    using Infrastructure.Data.Entities;

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
                TagId = 1,
                LocationId = 1,
            };

            return dashboard;
        }
    }
}
