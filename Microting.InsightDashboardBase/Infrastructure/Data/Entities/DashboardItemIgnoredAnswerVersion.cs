using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    public class DashboardItemIgnoredAnswerVersion : BaseEntity
    {
        public int AnswerId { get; set; }
        public int DashboardItemId { get; set; }
        public int DashboardItemIgnoredAnswerId { get; set; }
    }
}