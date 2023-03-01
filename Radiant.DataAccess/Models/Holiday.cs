using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Holiday
    {
        public long Holidayid { get; set; }
        public DateTime? Holiday1 { get; set; }
        public string Name { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
