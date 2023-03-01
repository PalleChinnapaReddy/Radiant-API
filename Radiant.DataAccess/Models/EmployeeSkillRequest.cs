namespace Radiant.DataAccess.Models
{
    public class EmployeeSkillRequest
    {
        public long EmpId { get; set; }
        public double OperatorErrors { get; set; }
        public double LineLeaderRating { get; set; }
        public double SkillRating { get; set; }
    }
}
