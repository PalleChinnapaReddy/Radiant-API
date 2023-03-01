namespace Radiant.Business.Models
{
    public class UpsertEmpSkillDto
    {
        public long? EmpId { get; set; }
        public double? AttendanceScore { get; set; }
        public double? SkillRating { get; set; }
        public double?  LineLeaderScore { get; set; }
        public double? OperatorErrors { get; set; }
    }
}
