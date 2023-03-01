using System.Collections.Generic;

namespace Radiant.Business.Models.Response
{
    public class EmployeeSearchResponseDto
    {
        public int TotalRows { get; set; }
        public List<EmployeeDto> Data { get; set; }
    }
}
