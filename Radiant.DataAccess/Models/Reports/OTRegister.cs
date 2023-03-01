using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class OTRegister
    {
        public long? SNo { get; set; }
        public long? EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public DateTime DOJ {get;set;}
        public string Gender { get; set; }
        public bool? ILDL { get; set; } 
        public string Qualification { get; set; }
        public string UANNo { get; set; } 
        public string ESICNo { get; set; }
        public DateTime AttendaceDate { get; set; }
        public int? DayOfDate { get; set; } 
        public decimal? OTHoursCount { get; set; }
        public string Holiday { get; set; }
        public string Absence { get; set; }
    }
}
