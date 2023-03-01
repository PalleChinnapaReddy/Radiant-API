namespace Radiant.DataAccess.Models.Reports
{
    public class VendorPayable
    {
        public string ContractorName { get; set; }
        public decimal? TotalGrossWages { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? PFEmployer { get; set; }
        public decimal? ESICEmploye { get; set; }
        public decimal? SupervisorSalary { get; set; }
        public decimal? TransportDeduction { get; set; }
        public decimal? CanteenDeduction { get; set; }
        public decimal? PenalityOnWeightage { get; set; }
        public decimal? OtherDeduction { get; set; }
        public decimal? RefundableDeposit { get; set; }
        public decimal? TotalHeadCount { get; set; }
        public decimal? TotalWorkedDays { get; set; }
        public decimal? TotalWorkingDays { get; set; }
        public decimal? TotalOTHours { get; set; }
        public decimal? TotalOTPay { get; set; }
        public decimal? ATotal { get; set; }
        public decimal? BTotalDeduction { get; set; }
        public decimal? GrossTotal { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? TDS { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? payabletovendar { get; set; }
    }
}
