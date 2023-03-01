using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class AttendanceCountByDayFilter
    {
        public int ContractorId { get; set; }

        public int LineId { get; set; }

        public int StageId { get; set; }

        public string ShiftIds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
