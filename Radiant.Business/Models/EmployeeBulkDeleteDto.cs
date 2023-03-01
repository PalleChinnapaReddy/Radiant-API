using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models
{
    public class EmployeeBulkDeleteDto
    {
        public List<long> Empids { get; set; }
        public string LeavingReason { get; set; }
        public string CommentsOnEmployeeRelieving { get; set; }
        public bool? IsEligibleForRehire { get; set; }
        public DateTime LastWorkingDay { get; set; }
    }
}
