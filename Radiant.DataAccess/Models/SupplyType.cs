using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class SupplyType
    {
        public SupplyType()
        {
            ContractorTracker = new HashSet<ContractorTracker>();
            Employee = new HashSet<Employee>();
        }

        public long Supplytypeid { get; set; }
        public string Typedetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<ContractorTracker> ContractorTracker { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
