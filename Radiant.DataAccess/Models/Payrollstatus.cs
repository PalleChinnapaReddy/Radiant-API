using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Payrollstatus
    {
        public Payrollstatus()
        {
            Payrollconfig = new HashSet<Payrollconfig>();
        }

        public long Payrollstatusid { get; set; }
        public string Payrollstatus1 { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Payrollconfig> Payrollconfig { get; set; }
    }
}
