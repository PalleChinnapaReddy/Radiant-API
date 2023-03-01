using System;

namespace Radiant.Business.Models
{
    public class HeadCountAssignedTypeDto
    {
        public long DepartmentLineId { get; set; }
        public long ContractorHeadCount { get; set; }
        public long StaffHeadCount { get; set; }
        public long ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
