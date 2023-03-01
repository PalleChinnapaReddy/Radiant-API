using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class ContractorTracker
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

        public virtual Contractor Contractor { get; set; }
        public virtual SupplyType Supplytype { get; set; }
    }
}
