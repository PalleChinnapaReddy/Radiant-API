using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Stage
    {
        public Stage()
        {
            Employee = new HashSet<Employee>();
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
        }

        public long Stageid { get; set; }
        public string Stagedescription { get; set; }
        public long? Lineid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Departmentid { get; set; }
        public long? Subdepartmentid { get; set; }

        public virtual Department Department { get; set; }
        public virtual Line Line { get; set; }
        public virtual Department Subdepartment { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
    }
}
