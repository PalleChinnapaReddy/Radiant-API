using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.Reports
{
    public class AttendanceReportByDayFilterDto
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string StageId { get; set; }
        public string ShiftId { get; set; }
        public string Contractor { get; set; }
        public string LineId { get; set; }
        public string InActivePresent { get; set; }

    }
}
