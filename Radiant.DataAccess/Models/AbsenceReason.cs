using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class AbsenceReason
    {
        public AbsenceReason()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
        }

        public long Absencereasonid { get; set; }
        public string Absencereasondetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
}
