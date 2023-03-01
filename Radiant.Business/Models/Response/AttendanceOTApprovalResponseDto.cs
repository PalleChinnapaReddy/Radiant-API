using System.Collections.Generic;

namespace Radiant.Business.Models.Response
{
    public class AttendanceOTApprovalResponseDto
    {
        public List<AttendanceOtApprovalDto> PendingRequests { get; set; }
        public List<AttendanceOtApprovalDto> ValidatedRequests { get; set; }
        public long? TotalPendingCount { get; set; }
        public long? TotalValidatedCount { get; set; }

    }
}
