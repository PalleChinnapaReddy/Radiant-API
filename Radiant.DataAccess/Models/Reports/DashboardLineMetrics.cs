namespace Radiant.DataAccess.Models.Reports
{
    public class DashboardLineMetrics
    {
        public long? LineId { get; set; }
        public string linedetails { get; set; }
        public long? TotalStages { get; set; }
        public string ShiftDetails { get; set; }
        public long? ShiftId { get; set; }
        public long? Present { get; set; }
        public long? TotalAssigned { get; set; }
    }
}
