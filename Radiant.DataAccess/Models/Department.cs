using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentlinemappingParentdepartment = new HashSet<Departmentlinemapping>();
            DepartmentlinemappingSubdepartment = new HashSet<Departmentlinemapping>();
            EmployeeCurrentDepartment = new HashSet<Employee>();
            EmployeeRoleTracker = new HashSet<EmployeeRoleTracker>();
            EmployeeSubdepartment = new HashSet<Employee>();
            StageDepartment = new HashSet<Stage>();
            StageSubdepartment = new HashSet<Stage>();
        }

        public long Departmentid { get; set; }
        public string Departmentdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? Parentdepartmentid { get; set; }

        public virtual ICollection<Departmentlinemapping> DepartmentlinemappingParentdepartment { get; set; }
        public virtual ICollection<Departmentlinemapping> DepartmentlinemappingSubdepartment { get; set; }
        public virtual ICollection<Employee> EmployeeCurrentDepartment { get; set; }
        public virtual ICollection<EmployeeRoleTracker> EmployeeRoleTracker { get; set; }
        public virtual ICollection<Employee> EmployeeSubdepartment { get; set; }
        public virtual ICollection<Stage> StageDepartment { get; set; }
        public virtual ICollection<Stage> StageSubdepartment { get; set; }
    }
}
