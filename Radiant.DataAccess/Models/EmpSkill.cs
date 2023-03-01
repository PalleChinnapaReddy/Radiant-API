using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radiant.DataAccess.Models
{
    public class EmpSkill
    {
        public long EmployeeSkillId { get; set; }
        public long? EmpId { get; set; }
        public long? EmpCode { get; set; }
        public DateTime? RatingDate { get; set; }
        public double? AttendanceScore { get; set; }
        public double? SkillRating { get; set; }
        public double? LineLeaderRating { get; set; }
        public double? LineLeaderScore { get; set; }
        public double? OperatorErrors { get; set; }
        public string RetrainingText { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public long? LineId { get; set; }
        [NotMapped]
        public string LineDescription { get; set; }
        [NotMapped]
        public long? DesignationId { get; set; }
        [NotMapped]
        public string DesignationDescription { get; set; }
        [NotMapped]
        public long? Shiftid { get; set; }
        [NotMapped]
        public string Shiftdetails { get; set; }
    }
}
