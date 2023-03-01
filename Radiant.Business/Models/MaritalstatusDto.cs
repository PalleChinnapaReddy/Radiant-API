using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class MaritalstatusDto
    {
        public MaritalstatusDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public long Maritalstatusid { get; set; }
        public string Maritalstatus1 { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
