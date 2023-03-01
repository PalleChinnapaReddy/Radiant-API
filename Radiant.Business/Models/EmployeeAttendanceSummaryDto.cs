using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class EmployeeAttendanceSummaryDto
    {
        public long Employeeattendancesummaryid { get; set; }
        public DateTime? Attendancedate { get; set; }
        public int? Present { get; set; }
        public int? Absent { get; set; }
        public long? Lineid { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual LineDto Line { get; set; }
    }
}
