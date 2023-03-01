using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class AttendanceCountByShift
    {
        public DateTime? AttendanceDate { get; set; }
        public string ShiftDetails { get; set; }
        public int Assigned { get; set; }
        public int? Present { get; set; }
    }
}
