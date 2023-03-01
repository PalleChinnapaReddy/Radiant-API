using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Payrollconfig
    {
        public long Payrollconfigid { get; set; }
        public double? Esic { get; set; }
        public double? Hra { get; set; }
        public double? Pf { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public double? Basic { get; set; }
        public double? Professionaltax1500 { get; set; }
        public double? Attendanceincentive { get; set; }
        public double? Otperhour { get; set; }
        public double? Nightshiftallowance { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public long? Payrollstatusid { get; set; }
        public long? ReviewedBy { get; set; }
        public long? ApprovedBy { get; set; }
        public double? Professionaltax2000 { get; set; }
        public string Uploadedfilelocation { get; set; }

        public virtual Payrollstatus Payrollstatus { get; set; }
    }
}
