using System;

namespace Radiant.Business.Models
{
    public class ScreensDto
    {
        public long Screenid { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }
    }
}
