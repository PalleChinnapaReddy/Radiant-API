namespace Radiant.DataAccess.Models
{
    public class UpsertEmpSkill
    {
        public long? EmpId { get; set; }
        public double? AttendanceScore { get; set; }
        public double? SkillRating { get; set; }
        public double?  LineLeaderScore { get; set; }
        public double? OperatorErrors { get; set; }
    }
}
