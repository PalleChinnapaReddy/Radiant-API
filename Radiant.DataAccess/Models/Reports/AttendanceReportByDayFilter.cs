using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class AttendanceReportByDayFilter
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
