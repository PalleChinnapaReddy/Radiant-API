using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class ConsolidationAttendanceResponseDto
    {
        public int TotalRows { get; set; }
        public List<ConsolidatedAttendancebyMonthDto> Data { get; set; }
    }
}
