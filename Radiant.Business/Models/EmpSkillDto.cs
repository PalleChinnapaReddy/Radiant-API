using System;

namespace Radiant.Business.Models
{
    public class EmpSkillDto
    {
        public long? EmpId { get; set; }
        public long? EmpCode { get; set; }
        public DateTime? RatingDate { get; set; }
        public double? AttendanceScore { get; set; }
        public double? SkillRating { get; set; }
        public double? LineLeaderRating { get; set; }
        public double? LineLeaderScore { get; set; }
        public double? OperatorErrors { get; set; }
        public string RetrainingText { get; set; }
        public string Name { get; set; }
        public long? LineId { get; set; }
        public string LineDescription { get; set; }
        public long? DesignationId { get; set; }
        public string DesignationDescription { get; set; }
        public long? Shiftid { get; set; }
        public string Shiftdetails { get; set; }
        public long EmployeeSkillId { get; set; }
    }
}
