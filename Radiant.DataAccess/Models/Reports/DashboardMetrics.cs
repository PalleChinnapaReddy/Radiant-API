namespace Radiant.DataAccess.Models.Reports
{
    public class DashboardMetrics
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
