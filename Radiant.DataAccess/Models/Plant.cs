using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Plant
    {
        public Plant()
        {
            Employee = new HashSet<Employee>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
            Line = new HashSet<Line>();
            Payrollshift = new HashSet<Payrollshift>();
            Shift = new HashSet<Shift>();
        }

        public long Plantid { get; set; }
        public string Plantdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Plantlocation { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
        public virtual ICollection<Line> Line { get; set; }
        public virtual ICollection<Payrollshift> Payrollshift { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
    }
}
