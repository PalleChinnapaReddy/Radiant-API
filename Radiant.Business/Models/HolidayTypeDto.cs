using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models
{
    public class HolidayTypeDto
    {
        public long Holidaytypeid { get; set; }
        public string Holidaytypedetails { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

    }
}
