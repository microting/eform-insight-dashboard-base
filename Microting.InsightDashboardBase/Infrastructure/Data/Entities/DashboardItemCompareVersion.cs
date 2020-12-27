using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    public class DashboardItemCompareVersion : BaseEntity
    {
        public int? LocationId { get; set; }
        public int? TagId { get; set; }
        public int Position { get; set; }
        public int DashboardItemId { get; set; }
        public int DashboardItemCompareId { get; set; }
    }
}