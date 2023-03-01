using System;

namespace Radiant.DataAccess.Models
{
    public class ConsolidatedAttendanceByMonthFilter
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public long? EmpCode { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
