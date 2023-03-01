namespace Radiant.DataAccess.Models.Reports
{
    public class DashboardShiftMetrics
    {
        public string ShiftDetails { get; set; }
        public long? TotalPresent { get; set; }
        public long? ActualTotalAssigned { get; set; }
        public long? ShiftId { get; set; }
    }
}
