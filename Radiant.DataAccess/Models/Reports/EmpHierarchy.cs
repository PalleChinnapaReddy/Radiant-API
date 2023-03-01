using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class EmpHierarchy
    {
        public long EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public long? ManagerId { get; set; }
        public int HelirarchyLevel { get; set; }
    }
}
