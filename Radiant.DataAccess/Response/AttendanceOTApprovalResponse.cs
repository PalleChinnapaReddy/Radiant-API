using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Response
{
    public class AttendanceOTApprovalResponse
    {
        public List<AttendanceOtApproval> PendingRequests { get; set; }
        public List<AttendanceOtApproval> ValidatedRequests { get; set; }

        public long? TotalPendingCount { get; set; }
        public long? TotalValidatedCount { get; set; }
    }
}
