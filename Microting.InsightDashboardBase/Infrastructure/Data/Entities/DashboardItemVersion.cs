namespace Microting.InsightDashboardBase.Infrastructure.Data.Entities
{
    using eFormApi.BasePn.Infrastructure.Database.Base;
    using Enums;

    public class DashboardItemVersion : BaseEntity
    {
        public int FirstQuestionId { get; set; } // questions.id
        public int FilterQuestionId { get; set; } // ???
        public int FilterAnswerId { get; set; } // ???
        public DashboardPeriodUnits Period { get; set; }
        public DashboardChartTypes ChartType { get; set; }
        public int Position { get; set; }
        public int DashboardId { get; set; }
        public virtual Dashboard Dashboard { get; set; }
    }
}