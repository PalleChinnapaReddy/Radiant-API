using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public class AttendancePayrollResponse
    {
        public int TotalRows { get; set; }
        public List<AttendancePayroll> Data { get; set; }
    }
}
