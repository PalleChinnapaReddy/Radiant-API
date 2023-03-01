using System;

namespace Radiant.Business.Models
{
    public class EmployeeDeleteDto
    {
        public long Empid { get; set; }
        public string LeavingReason { get; set; }
        public string CommentsOnEmployeeRelieving { get; set; }
        public bool? IsEligibleForRehire { get; set; }
        public DateTime LastWorkingDay { get; set; }

    }
}
