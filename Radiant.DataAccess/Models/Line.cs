using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Line
    {
        public Line()
        {
            Departmentlinemapping = new HashSet<Departmentlinemapping>();
            Employee = new HashSet<Employee>();
            EmployeeAttendanceSummary = new HashSet<EmployeeAttendanceSummary>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
            Stage = new HashSet<Stage>();
        }

        public long Lineid { get; set; }
        public string Linedescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Plantid { get; set; }

        public virtual Plant Plant { get; set; }
        public virtual ICollection<Departmentlinemapping> Departmentlinemapping { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeAttendanceSummary> EmployeeAttendanceSummary { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
    }
}
