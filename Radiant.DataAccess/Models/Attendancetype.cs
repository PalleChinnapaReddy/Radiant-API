using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Attendancetype
    {
        public Attendancetype()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
}
