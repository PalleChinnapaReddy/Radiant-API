using System;

namespace Radiant.Business.Models
{
    public partial class PayrolldeductionDto
    {
        public long Pdid { get; set; }
        public long? Empcode { get; set; }
        public string Month { get; set; }
        public long? Year { get; set; }
        public double? Subleaderallowance { get; set; }
        public double? Otherallowance { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
        public double? Miscellaneous { get; set; }
        public double? Refundabledeposit { get; set; }
        public double? Otherdeduction { get; set; }
        public double? Canteendeductions { get; set; }
        public double? Transportdeductions { get; set; }
        public double? Lcmeligible { get; set; }
        public double? Ratingallowances { get; set; }
        public long? Monthnumber { get; set; }
        public virtual EmployeeDto EmpcodeNavigation { get; set; }
    }
}
