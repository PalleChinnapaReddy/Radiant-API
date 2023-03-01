using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class EmployeeRoleTrackerDto
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
        public long? Subdepartmentid { get; set; }
        public bool? Ildl { get; set; }
        public virtual EmployeeDto Emp { get; set; }
        public virtual RoleDto Role { get; set; }
        public long? Departmentid { get; set; }
    }
}
