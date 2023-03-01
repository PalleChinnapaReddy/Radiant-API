using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class StageDto
    {
        public StageDto()
        {
            EmployeeTracker = new HashSet<EmployeeTrackerDto>();
        }

        public long Stageid { get; set; }
        public string Stagedescription { get; set; }
        public long? Lineid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? PresentEmployeeCount { get; set; }
        public long? ActiveEmployeeCount { get; set; }

        public long? Departmentid { get; set; }
        public long? Subdepartmentid { get; set; }

        public virtual DepartmentDto Department { get; set; }
        public virtual DepartmentDto Subdepartment { get; set; }
        public virtual LineDto Line { get; set; }
        public virtual ICollection<EmployeeTrackerDto> EmployeeTracker { get; set; }
    }
}
