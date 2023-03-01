using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class HeadCountReportByDayFilter
    {
        public DateTime GivenDate { get; set; }
        public string StageId { get; set; }
        public string ShiftId { get; set; }
        public string Contractor { get; set; }
        public string LineId { get; set; }

    }

}
