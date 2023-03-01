using System;

namespace Radiant.Business.Models
{
    public class ConsolidatedAttendanceByMonthFilterDto
    {
        public ConsolidatedAttendanceByMonthFilterDto()
        {
            PageSize = int.MaxValue;
        }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public long? EmpCode { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
