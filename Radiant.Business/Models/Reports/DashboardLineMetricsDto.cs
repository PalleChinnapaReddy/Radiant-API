namespace Radiant.Business.Models.Reports
{
    public class DashboardLineMetricsDto
    {
        public long? LineId { get; set; }
        public string linedetails { get; set; }
        public long? TotalStages { get; set; }
        public long? Present { get; set; }
        public long? TotalAssigned { get; set; }
        public string ShiftDetails { get; set; }
        public long? ShiftId { get; set; }
    }
}
