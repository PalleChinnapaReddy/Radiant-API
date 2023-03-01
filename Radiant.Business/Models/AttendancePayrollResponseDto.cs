using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class AttendancePayrollResponseDto
    {
        public int TotalRows { get; set; }
        public List<AttendancePayrollDto> Data { get; set; }
    }
}
