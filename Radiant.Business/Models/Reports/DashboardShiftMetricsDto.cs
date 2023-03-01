namespace Radiant.Business.Models.Reports
{
    public class DashboardShiftMetricsDto
    {
        public string ShiftDetails { get; set; }
        public long? TotalPresent { get; set; }
        public long? ActualTotalAssigned { get; set; }
        public long? ShiftId { get; set; }

    }
}
