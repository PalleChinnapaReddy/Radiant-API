using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Shift
    {
        public Shift()
        {
            Employee = new HashSet<Employee>();
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
            Payrollshift = new HashSet<Payrollshift>();
        }

        public long Shiftid { get; set; }
        public string Shiftdetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public TimeSpan? Shiftstarttime { get; set; }
        public TimeSpan? Shiftendtime { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Shiftactivedate { get; set; }
        public DateTime? Shiftinactivedate { get; set; }
        public long? Plantid { get; set; }
        public TimeSpan? Shiftstartthresholdfrom { get; set; }
        public TimeSpan? Shiftstartthresholdto { get; set; }

        public virtual Plant Plant { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
        public virtual ICollection<Payrollshift> Payrollshift { get; set; }
    }
}
