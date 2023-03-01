using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.Reports
{
    public class AttendanceCountByDayDto
    {
        public DateTime? AttendanceDate { get; set; }
        public int DateDay { get; set; }
        public int Assigned { get; set; }
        public int? Present { get; set; }
    }
}
