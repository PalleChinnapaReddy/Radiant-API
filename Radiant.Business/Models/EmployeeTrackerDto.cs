using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class EmployeeTrackerDto
    {
        public long Emptrackerid { get; set; }
        public long? Empid { get; set; }
        public long? Contractorid { get; set; }
        public long? Lineid { get; set; }
        public long? Stageid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Plantid { get; set; }
        public long? Shiftid { get; set; }

        public virtual ContractorDto Contractor { get; set; }
        public virtual EmployeeDto Emp { get; set; }
        public virtual LineDto Line { get; set; }
        public virtual PlantDto Plant { get; set; }
        public virtual ShiftDto Shift { get; set; }
        public virtual StageDto Stage { get; set; }
    }
}
