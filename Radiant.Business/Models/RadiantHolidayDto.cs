using System;

namespace Radiant.Business.Models
{
    public partial class RadiantHolidayDto
    {
        public long Holidayid { get; set; }
        public DateTime? Holiday { get; set; }
        public string Name { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? HolidayTypeId { get; set; }
    }
}
