using System;

namespace Radiant.Business.Models
{
    public class ShiftDto
    {
        public ShiftDto ()
        {
            //Employee = new HashSet<EmployeeDto>();
            //EmployeeAttendance = new HashSet<EmployeeAttendanceDto>();
            //EmployeeTracker = new HashSet<EmployeeTrackerDto>();
        }

        public long Shiftid { get; set; }
        public string Shiftdetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public TimeSpan? Shiftstarttime { get; set; }
        public TimeSpan? Shiftendtime { get; set; }
        public DateTime? Shiftactivedate { get; set; }
        public DateTime? Shiftinactivedate { get; set; }
        public TimeSpan? Shiftstartthresholdfrom { get; set; }
        public TimeSpan? Shiftstartthresholdto { get; set; }
        public bool? Isactive { get; set; }

        public int EmployeeCount { get; set; }
        public long? Plantid { get; set; }

        public virtual PlantDto Plant { get; set; }

        //public virtual ICollection<EmployeeDto> Employee { get; set; }
        //public virtual ICollection<EmployeeAttendanceDto> EmployeeAttendance { get; set; }
        //public virtual ICollection<EmployeeTrackerDto> EmployeeTracker { get; set; }
    }
}
