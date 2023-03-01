using System;

namespace Radiant.Business.Models.Reports
{
    public class EmpOTReportDto
    {

        public DateTime? AttenDate { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string PresentStatus { get; set; }
        public string Department { get; set; }
        public string DesignationDescription { get; set; }
        public DateTime? DOJ { get; set; }
        public string Gender { get; set; }
        public bool ILDL { get; set; }
        public string Qualification { get; set; }
        public string UAN { get; set; }
        public string ESICNo { get; set; }
        public string Details { get; set; }
    }
}
