using System;
using System.Collections.Generic;
using System.Collections;

namespace Radiant.Business.Models
{
    public class EmployeeAttendanceDto
    {
        public EmployeeAttendanceDto()
        {
            AttendanceOtApproval = new HashSet<AttendanceOtApprovalDto>();
        }

        public long Employeeattendanceid { get; set; }
        public DateTime? Attendancedate { get; set; }
        public long? Empid { get; set; }
        public bool? Ispresent { get; set; }
        public DateTime? Checkintime { get; set; }
        public DateTime? Checkouttime { get; set; }
        public long? Absencereasonid { get; set; }
        public bool? Ot { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Shiftid { get; set; }
        public long? Stageid { get; set; }
        public int AttendanceTypeId { get; set; }
        public DateTime? CompOffDate { get; set; }
        public double? Breaktime { get; set; }
        public double? Workedhours { get; set; }
        public double? Overtimehours { get; set; }
        public long? DepartmentId { get; set; }
        public string Department { get; set; }
        public long? SubDepartmentId { get; set; }
        public string SubDepartment { get; set; }
        public long? ContractorId { get; set; }
        public string Contractor { get; set; }
        public long? Payrollshiftid { get; set; }
        public double? Extraovertimehours { get; set; }

        public virtual AbsenceReasonDto Absencereason { get; set; }
        public virtual AttendancetypeDto AttendanceType { get; set; }

        public virtual EmployeeDto Emp { get; set; }
        public virtual ShiftDto Shift { get; set; }
        public virtual StageDto Stage { get; set; }
        public virtual ICollection<AttendanceOtApprovalDto> AttendanceOtApproval { get; set; }

    }
}
