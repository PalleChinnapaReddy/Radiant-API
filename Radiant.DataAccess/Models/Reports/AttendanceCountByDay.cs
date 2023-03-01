using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class AttendanceCountByDay
    {
        public DateTime? AttendanceDate { get; set; }
        public int DateDay { get; set; }
        public int Assigned { get; set; }
        public int? Present { get; set; }
    }
}
