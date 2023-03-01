using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class EmpOTReportFilter
    {
        public string Contractor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
