using System.Collections.Generic;

namespace Radiant.Business.Models.Reports
{
    public class EmpHierarchyDto
    {
        public long EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public long? ManagerId { get; set; }
        public int HelirarchyLevel { get; set; }
        public List<EmpHierarchyDto> Children { get; set; }
    }
}
