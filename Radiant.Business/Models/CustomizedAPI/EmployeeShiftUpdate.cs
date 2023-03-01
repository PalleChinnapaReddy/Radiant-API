using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.CustomizedAPI
{
    public class EmployeeShiftUpdate
    {
        public List<EmployeeDto> Employees { get; set; }
        public long? Contractorid { get; set; }
        public long? Lineid { get; set; }
        public long? Stageid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Plantid { get; set; }
        public long? Shiftid { get; set; }
        public bool isTemporary { get; set; }
    }
}
