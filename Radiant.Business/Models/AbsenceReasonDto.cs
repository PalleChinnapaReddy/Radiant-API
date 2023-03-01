using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class AbsenceReasonDto
    {
        public AbsenceReasonDto()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendanceDto>();
        }

        public long Absencereasonid { get; set; }
        public string Absencereasondetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeAttendanceDto> EmployeeAttendance { get; set; }
    }
}
