namespace Radiant.Business.Models.Reports
{
    public class DashboardMetricsDto
    {
        public long? Active { get; set; }
        public long? RegisteredToday { get; set; } 
        public long? TerminatedToday { get; set; }
        public long? Present { get; set; }
        public long? OnLeave { get; set; }
        public long? AbsentEmployees { get; set; }
        public long? InactivePresent { get; set; }
    }
}
