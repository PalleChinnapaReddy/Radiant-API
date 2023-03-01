using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class ContractorTrackerDto
    {
        public long Contactortrackerid { get; set; }
        public long? Contractorid { get; set; }
        public long? Supplytypeid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ContractorDto Contractor { get; set; }
        public virtual SupplyTypeDto Supplytype { get; set; }
    }
}
