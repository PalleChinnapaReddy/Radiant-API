using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.FilterModels
{
    public class EmployeeSkillSearchDto
    {
        public long? ManagerId { get; set; }
        public DateTime RatingDate { get; set; }
        public int Active { get; set; }
    }
}
