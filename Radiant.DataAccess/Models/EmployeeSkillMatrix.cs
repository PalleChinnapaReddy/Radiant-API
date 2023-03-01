using System;

namespace Radiant.DataAccess.Models
{
    public class EmployeeSkillMatrix
    {
        public long? EmpId { get; set; }
        public long? EmpCode { get; set; }
        public string EmployeeName { get; set; }
        public string LineDescription { get; set; }
        public string DepartmentDescription { get; set; }
        public string DesignationDescription { get; set; }
        public string ShiftDetails { get; set; }
        public double? TenureInDays { get; set; }
        public string SkillProficiency { get; set; }
        public string OperatorErrors { get; set; }
        public string LineLeaderRating { get; set; }
        public string AttendanceScore { get; set; }
        public string SkillRatingScore { get; set; }
        public string LineLeaderScore { get; set; }
        public string ReTraining { get; set; }
        public double? OperatorPerformanceScore { get; set; } 
        public DateTime? ScoreAsOF { get; set; }
    }
}
