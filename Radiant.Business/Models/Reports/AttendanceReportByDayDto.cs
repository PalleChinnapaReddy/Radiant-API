using System;

namespace Radiant.Business.Models.Reports
{
    public class AttendanceReportByDayDto
    {
        public DateTime? PunchDate { get; set; }
        public long? EmployeeId { get; set; }
        public long? Id { get; set; }

        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string CategoryName { get; set; }
        public string WorkLocation { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? ShiftIn { get; set; }
        public TimeSpan? PunchInTime { get; set; }
        public DateTime? PunchInDate { get; set; }
        public TimeSpan? PunchOutTime { get; set; }
        public DateTime? PunchOutDate { get; set; }
        public TimeSpan? ShiftOut { get; set; }
        public int? TotalMinuteWorked { get; set; }
        public string AttendanceStatus { get; set; }
        public int? OtWorkedMinutes { get; set; }
        public int? LateBy { get; set; }
        public int? EarlyBy { get; set; }
        public long? ManagerEmpId { get; set; }
        public string ManagerName { get; set; }
        public string LineName { get; set; }
        public string StageName { get; set; }
        public bool? ILDL { get; set; }
        public string Subdepartmentname { get; set; }
    }
}
