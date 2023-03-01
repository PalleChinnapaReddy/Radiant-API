using System;

namespace Radiant.Business.Models
{
    public partial class PayrollshiftDto
    {
        public long Payrollshiftid { get; set; }
        public long? Shiftid { get; set; }
        public string Shiftdetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public TimeSpan? Shiftstarttime { get; set; }
        public TimeSpan? Shiftendtime { get; set; }
        public double? Hours { get; set; }
        public bool Iscreatedbyhr { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Shiftactivedate { get; set; }
        public long? Plantid { get; set; }
        public TimeSpan? Shiftstartthresholdfrom { get; set; }
        public TimeSpan? Shiftstartthresholdto { get; set; }
        public bool? Isedited { get; set; }
        public TimeSpan? Maxshiftendtime { get; set; }

        public virtual PlantDto  Plant { get; set; }
        public virtual ShiftDto Shift { get; set; }
    }
}
