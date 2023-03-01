using System;

namespace Radiant.Business.Models
{
    public class AttendancePayrollDto
    {
        public int RNum { get; set; }
        public DateTime PunchDate { get; set; }
        public long? EmployeeCode { get; set; }
        public long? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string SubDepartmentName { get; set; }
        public string RoleName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string DesignationName { get; set; }
        public string CategoryName { get; set; }
        public string WorkLocation { get; set; }
        public string LineName { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? ShiftIn { get; set; }
        public TimeSpan? PunchInTime { get; set; }
        public DateTime? PunchInDate { get; set; }
        public TimeSpan? PunchOutTime { get; set; }
        public DateTime PunchOutDate { get; set; }
        public TimeSpan? ShiftOut { get; set; }
        public TimeSpan? RegularizationInTime { get; set; }
        public TimeSpan? RegularizationOutTime { get; set; }
        public int? TotalMinuteWorked { get; set; }
        public string AttendanceStatus { get; set; }
        public int? TotalOtWorkedMinutes { get; set; }
        public int? ApprovedOtWorkedMinutes { get; set; }
        public int? LateBy { get; set; }
        public int? EarlyBy { get; set; }
        public long? ManagerEmpId { get; set; }
        public string ManagerName { get; set; }
        public decimal? A { get; set; }
        public decimal? P { get; set; }
        public decimal? WO { get; set; }
        public decimal? H { get; set; }
        public decimal? WOP { get; set; }
        public decimal? HP { get; set; }
        public decimal? CO { get; set; }
        public string EmployeeStatusType { get; set; }
        public decimal? IAP { get; set; }
        public decimal? WorkingDays { get; set; }
        public decimal? WorkingDaysPresent { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public decimal WOPPIAP { get; set; }
        public decimal HPPIAP { get; set; }
        public string AttendanceComments { get; set; }
        public bool? ILDL { get; set; }
    }
}
