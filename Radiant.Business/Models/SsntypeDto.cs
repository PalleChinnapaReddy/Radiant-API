using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class SsntypeDto
    {
        public SsntypeDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public long Ssntypeid { get; set; }
        public string Ssntypedetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
