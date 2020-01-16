namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using eFormApi.BasePn.Infrastructure.Database.Base;

    public class DashboardItemVersion : BaseEntity
    {
        public int Position { get; set; }
        public int DashboardId { get; set; }
        public virtual Dashboard Dashboard { get; set; }
    }
}