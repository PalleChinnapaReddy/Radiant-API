using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.Reports
{
    public class AttendanceCountByShiftDto
    {
        public DateTime? AttendanceDate { get; set; }
        public string ShiftDetails { get; set; }
        public int Assigned { get; set; }
        public int? Present { get; set; }
    }
}
