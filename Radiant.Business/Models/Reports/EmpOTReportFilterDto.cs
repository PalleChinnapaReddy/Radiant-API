using System;

namespace Radiant.Business.Models.Reports
{
    public class EmpOTReportFilterDto
    {
        public string Contractor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
