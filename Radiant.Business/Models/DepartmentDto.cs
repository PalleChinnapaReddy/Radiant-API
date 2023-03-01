using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class DepartmentDto
    {
        public DepartmentDto()
        {
            DepartmentlinemappingParentdepartment = new HashSet<DepartmentlinemappingDto>();
            DepartmentlinemappingSubdepartment = new HashSet<DepartmentlinemappingDto>();
            //EmployeeCurrentDepartment = new HashSet<EmployeeDto>();
            //EmployeeRoleTracker = new HashSet<EmployeeRoleTrackerDto>();
            //EmployeeSubdepartment = new HashSet<EmployeeDto>();
        }
        public long Departmentid { get; set; }
        public string Departmentdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? Parentdepartmentid { get; set; }

        public int EmployeeCount { get; set; }
        public virtual ICollection<DepartmentlinemappingDto> DepartmentlinemappingParentdepartment { get; set; }
        public virtual ICollection<DepartmentlinemappingDto> DepartmentlinemappingSubdepartment { get; set; }

        //public virtual ICollection<EmployeeDto> EmployeeCurrentDepartment { get; set; }
        //public virtual ICollection<EmployeeDto> EmployeeSubdepartment { get; set; }

        //public virtual ICollection<EmployeeRoleTrackerDto> EmployeeRoleTracker { get; set; }
        public virtual ICollection<Stage> StageDepartment { get; set; }
        public virtual ICollection<Stage> StageSubdepartment { get; set; }
    }
}
