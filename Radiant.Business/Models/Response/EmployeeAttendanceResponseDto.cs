using System.Collections.Generic;

namespace Radiant.Business.Models.Response
{
    public class EmployeeAttendanceResponseDto
    {
        public int TotalRows { get; set; }
        public List<EmployeeAttendanceDto> Data { get; set; }
    }
}
