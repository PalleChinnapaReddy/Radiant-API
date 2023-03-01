using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class AttendancetypeDto
    {
        public AttendancetypeDto()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendanceDto>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
        public virtual ICollection<EmployeeAttendanceDto> EmployeeAttendance { get; set; }
    }
}
