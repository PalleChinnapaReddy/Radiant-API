using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class RadiantHoliday
    {
        public long Holidayid { get; set; }
        public DateTime? Holiday { get; set; }
        public string Name { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Holidaytypeid { get; set; }

        public virtual Holidaytype Holidaytype { get; set; }
    }
}
