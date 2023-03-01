using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class AttendanceOtApproval
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

        public virtual EmployeeAttendance Employeeattendance { get; set; }
        public virtual OtStatus Otstatus { get; set; }
    }
}
