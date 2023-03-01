using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class OtStatusDto
    {
        public OtStatusDto()
        {
            AttendanceOtApproval = new HashSet<AttendanceOtApprovalDto>();
        }

        public long Otstatusid { get; set; }
        public string Otstatusdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<AttendanceOtApprovalDto> AttendanceOtApproval { get; set; }
    }
}
