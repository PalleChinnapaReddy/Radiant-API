using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class SupplyTypeDto
    {
        public SupplyTypeDto()
        {
            ContractorTracker = new HashSet<ContractorTrackerDto>();
            Employee = new HashSet<EmployeeDto>();
        }

        public long Supplytypeid { get; set; }
        public string Typedetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<ContractorTrackerDto> ContractorTracker { get; set; }
    }
}
