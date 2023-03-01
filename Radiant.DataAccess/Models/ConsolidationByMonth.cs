namespace Radiant.DataAccess.Models
{
    public class ConsolidationByMonth
    {
        public int? MonthNumber { get; set; }
        public string MonthName { get; set; }
        public double? Basic { get; set; }
        public double? HRA { get; set; }
        public double? AttendanceIncentive { get; set; }
        public double? OTPerHourDoubleRate { get; set; }
        public double? NightShiftAllowances { get; set; }
        public double? PFEmployer { get; set; }
        public double? ESICEmployer { get; set; }
        public double? ServiceCharge { get; set; }
        public double? Canteen { get; set; }
        public double? Transport { get; set; }
        public double? PFEmployee { get; set; }
        public double ESICEmployee { get; set; }
    }
}
