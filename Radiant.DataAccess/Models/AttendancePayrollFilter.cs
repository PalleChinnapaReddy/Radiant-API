using System;

namespace Radiant.DataAccess.Models
{
    public class AttendancePayrollFilter
    {
        public AttendancePayrollFilter()
        {
            EmpCode = "-1";
        }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string StageId { get; set; }
        public string ShiftId { get; set; }
        public string Contractor { get; set; }
        public string LineId { get; set; }
        public string InActivePresent { get; set; }
        public string EmpCode { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
