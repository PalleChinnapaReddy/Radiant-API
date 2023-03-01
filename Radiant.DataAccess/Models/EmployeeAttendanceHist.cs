using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class EmployeeAttendanceHist
    {
        public long? Employeeattendanceid { get; set; }
        public DateTime? Attendancedate { get; set; }
        public long? Empid { get; set; }
        public bool? Ispresent { get; set; }
        public DateTime? Checkintime { get; set; }
        public DateTime? Checkouttime { get; set; }
        public long? Absencereasonid { get; set; }
        public bool? Ot { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Shiftid { get; set; }
        public long? Stageid { get; set; }
        public int? AttendanceTypeId { get; set; }
        public DateTime? CompOffDate { get; set; }
        public double? Breaktime { get; set; }
        public double? Workedhours { get; set; }
        public double? Overtimehours { get; set; }
        public long? Payrollshiftid { get; set; }
    }
}
