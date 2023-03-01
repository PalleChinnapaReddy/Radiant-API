using Radiant.Business.Models.CustomizedAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.Response
{
    public class EmployeeLinesDashboardResponseDto
    {
        public int TotalRows { get; set; }
        public List<EmployeeLinesDashboardDto> Data { get; set; }
    }
}
