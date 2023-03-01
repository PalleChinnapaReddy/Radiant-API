using System;

namespace Radiant.DataAccess.Models
{
    public class EmployeeDeleteModel
    {
        public long Empid { get; set; }
        public string LeavingReason { get; set; }
        public string CommentsOnEmployeeRelieving { get; set; }
        public bool? IsEligibleForRehire { get; set; }
        public DateTime LastWorkingDay { get; set; }
    }
}
