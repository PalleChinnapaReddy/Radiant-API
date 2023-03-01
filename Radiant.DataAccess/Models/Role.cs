using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            Employee = new HashSet<Employee>();
            EmployeeRoleTracker = new HashSet<EmployeeRoleTracker>();
        }

        public long Roleid { get; set; }
        public string Roledetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
        public string Screendetails { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeRoleTracker> EmployeeRoleTracker { get; set; }
    }
}
