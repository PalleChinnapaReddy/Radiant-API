
using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class HeadCountReportByDay
    {
        public DateTime? AttendanceDate { get; set; }
        public string ShiftDetails { get; set; }
        public string ILDL { get; set; }
        public string DepartmentDescription { get; set; }
        public string EmpType { get; set; }


    }
}
