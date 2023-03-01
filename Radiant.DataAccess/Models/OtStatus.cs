using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class OtStatus
    {
        public OtStatus()
        {
            AttendanceOtApproval = new HashSet<AttendanceOtApproval>();
        }

        public long Otstatusid { get; set; }
        public string Otstatusdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<AttendanceOtApproval> AttendanceOtApproval { get; set; }
    }
}
