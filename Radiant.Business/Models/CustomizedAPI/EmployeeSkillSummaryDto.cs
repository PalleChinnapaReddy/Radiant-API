using System;
using System.Collections.Generic;

namespace Radiant.Business.Models.CustomizedAPI
{
    public class EmployeeSkillSummaryDto
    {
        public EmployeeSkillSummaryDto()
        {
            Ratings = new List<RatingDto>();
        }

        public long EmpId { get; set; }
        public long? EmpCode { get; set; }
        public string Name { get; set; }
        public long? DepartmentId { get; set; }
        public string Department { get; set; }
        public long? LineId { get; set; }
        public string Line { get; set; }
        public long? StageId { get; set; }
        public string Stage { get; set; }
        public List<RatingDto> Ratings { get; set; }
    }

    public class RatingDto
    {
        public DateTime RatingDate { get; set; }
        public float Rating { get; set; }
    }
}
