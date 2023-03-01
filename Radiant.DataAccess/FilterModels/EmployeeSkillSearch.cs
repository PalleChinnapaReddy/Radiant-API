using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class EmployeeSkillSearch
    {
        public long? ManagerId { get; set; }
        public DateTime RatingDate { get; set; }
        public int Active { get; set; }
    }
}
