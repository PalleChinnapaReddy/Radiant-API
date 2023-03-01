using System;
using System.Collections.Generic;
using System.Linq;

namespace Radiant.Business.Models
{
    public class RoleDto
    {
        public RoleDto()
        {
            //Employee = new HashSet<EmployeeDto>();
            //EmployeeRoleTracker = new HashSet<EmployeeRoleTrackerDto>();
        }

        public long Roleid { get; set; }
        public string Roledetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
        public string Screendetails { get; set; }

        public long? ActiveEmployeeCount { get; set; }
        public long? TotalEmployeeCount { get; set; }

        //public virtual ICollection<EmployeeDto> Employee { get; set; }
        //public virtual ICollection<EmployeeRoleTrackerDto> EmployeeRoleTracker { get; set; }
    }
}
