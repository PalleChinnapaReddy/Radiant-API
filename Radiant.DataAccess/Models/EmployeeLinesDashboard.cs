﻿namespace Radiant.DataAccess.Models
{
    public class EmployeeLinesDashboard
    {
        public long? EmpId { get; set; }
        public long? EmpCode { get; set; }
        public string Name { get; set; }

        public string Line { get; set; }
        public string Stage { get; set; }
        public bool IsPresent { get; set; }
        public double SkillRating { get; set; }
    }
}
