using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class EmployeeTracker
    {
        public long Emptrackerid { get; set; }
        public long? Empid { get; set; }
        public long? Contractorid { get; set; }
        public long? Lineid { get; set; }
        public long? Stageid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Plantid { get; set; }
        public long? Shiftid { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual Line Line { get; set; }
        public virtual Plant Plant { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
