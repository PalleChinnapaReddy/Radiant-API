using System;

namespace Radiant.Business.Models
{
    public class AttendanceOtApprovalDto
    {
        public long Attendanceapprovalid { get; set; }
        public long? Employeeattendanceid { get; set; }
        public long? Approvedempid { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Otstatusid { get; set; }
        public string Comment { get; set; }

        public virtual EmployeeAttendanceDto Employeeattendance { get; set; }
        public virtual OtStatusDto Otstatus { get; set; }
    }
}
