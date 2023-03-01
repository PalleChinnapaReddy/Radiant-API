using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public class ConsolidationAttendanceResponse
    {
        public int TotalRows { get; set; }
        public List<ConsolidatedAttendancebyMonth> Data { get; set; }
    }
}
