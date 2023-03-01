using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class EmployeeRoleTracker
    {
        public long Emproletrackerid { get; set; }
        public long? Empid { get; set; }
        public long? Roleid { get; set; }
        public double? Payperhour { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Departmentid { get; set; }
        public long? Subdepartmentid { get; set; }
        public bool? Ildl { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual Role Role { get; set; }
    }
}
