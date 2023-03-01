using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Holidaytype
    {
        public Holidaytype()
        {
            RadiantHoliday = new HashSet<RadiantHoliday>();
        }

        public long Holidaytypeid { get; set; }
        public string Holidaytypedetails { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<RadiantHoliday> RadiantHoliday { get; set; }
    }
}
