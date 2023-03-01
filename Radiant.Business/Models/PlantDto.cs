using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models
{
    public class PlantDto
    {
        public  PlantDto()
        {
            Employee = new HashSet<EmployeeDto>();
            EmployeeTracker = new HashSet<EmployeeTrackerDto>();
            Line = new HashSet<LineDto>();
            Shift = new HashSet<ShiftDto>();
        }

        public long Plantid { get; set; }
        public string Plantdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Plantlocation { get; set; }
        public virtual ICollection<EmployeeDto> Employee { get; set; }

        public virtual ICollection<EmployeeTrackerDto> EmployeeTracker { get; set; }
        public virtual ICollection<LineDto> Line { get; set; }
        public virtual ICollection<ShiftDto> Shift { get; private set; }
    }
}
