using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class LineDto
    {
        public LineDto()
        {
            Departmentlinemapping = new HashSet<DepartmentlinemappingDto>();
            EmployeeAttendanceSummary = new HashSet<EmployeeAttendanceSummaryDto>();
            EmployeeTracker = new HashSet<EmployeeTrackerDto>();
            Stage = new HashSet<StageDto>();
        }

        public long Lineid { get; set; }
        public string Linedescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Plantid { get; set; }
        public long? ActiveEmployeeCount { get; set; }

        public virtual PlantDto Plant { get; set; }
        public virtual ICollection<DepartmentlinemappingDto> Departmentlinemapping { get; set; }
        public virtual ICollection<EmployeeAttendanceSummaryDto> EmployeeAttendanceSummary { get; set; }
        public virtual ICollection<EmployeeTrackerDto> EmployeeTracker { get; set; }
        public virtual ICollection<StageDto> Stage { get; set; }
    }
}
