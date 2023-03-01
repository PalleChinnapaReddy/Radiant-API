using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class EmpOTReport
    {
        //attendate date, empid bigint, employeename character varying, presentstatus text,
        //department character varying, designationdescription character varying, doj date, gender character varying, ildl boolean,
        //qualification character varying, uan character varying, esic_no character varying, details text

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
