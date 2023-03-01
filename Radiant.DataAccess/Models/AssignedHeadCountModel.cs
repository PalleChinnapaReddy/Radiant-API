using System;

namespace Radiant.DataAccess.Models
{
    public class AssignedHeadCountModel
    {
        public long DepartmentLineId { get; set; }
        public long? ParentDepartmentId { get; set; }
        public long DepartmentId { get; set; }
        public long? LineId { get; set; }
        public string ParentDeptName { get; set; }
        public string SubDeptName { get; set; }
        public string LineDescription { get; set; }
        public long ContractorAssignedHeadCount { get; set; }
        public long StaffAssignedHeadCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
        public long? DisplayOrder { get; set; }
    }
}
