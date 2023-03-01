using System;

namespace Radiant.Business.Models.Reports
{
    public class WageSheetRegisterDto
    {
        public long? SNo { get; set; }
        public long? EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public DateTime DOJ { get; set; }
        public string Gender { get; set; }
        public bool? ILDL { get; set; }
        public string Qualification { get; set; }
        public string UANNo { get; set; }
        public string ESICNo { get; set; }
        public double? RateOfWagePerDay { get; set; }
        public double? Basic { get; set; }
        public double? HRA { get; set; }
        public double? RateOfWagePerMonth { get; set; }
        public double? WorkedDays { get; set; }
        public double? Othrs { get; set; }
        public double? ArrearsWorkedDays { get; set; }
        public double? ArrearsOthrs { get; set; }
        public double? EarnedBasic { get; set; }
        public double? EarnedHRA { get; set; }
        public double? EarnedGross { get; set; }
        public double? EarnedOTAmount { get; set; }
        public double? ArrearsBasic { get; set; }
        public double? ArrearsHRA { get; set; }
        public double? ArrearsEarnedGross { get; set; }
        public double? ArrearsOTAmount { get; set; }
        public double? SubLeaderLineLeaderPQCAllowance { get; set; }
        public double? OtherAllowance { get; set; }
        public double? NightShiftAllowance { get; set; }
        public double? GrossWages { get; set; }
        public double? EmployeePF { get; set; }
        public double? EmployeeESI { get; set; }
        public double? PT { get; set; }
        public double? RefundableCautionDeposit { get; set; }
        public double? OtherDeduction { get; set; }
        public double? FoodDeduction { get; set; }
        public double? TransportDeduction { get; set; }
        public double? TotalDeduction { get; set; }
        public double? NetSalary { get; set; }
    }
}
