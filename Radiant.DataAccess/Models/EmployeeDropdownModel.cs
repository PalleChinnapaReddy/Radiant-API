using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models
{
    public class EmployeeDropdownModel
    {
        public long EmpId { get; set; }
        public long EmpCode { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
    }
}
