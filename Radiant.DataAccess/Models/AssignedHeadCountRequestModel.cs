using System;

namespace Radiant.DataAccess.Models
{
    public class AssignedHeadCountRequestModel
    {
        public string DepartmentIds { get; set; }
        public long ShiftId { get; set; }
        public DateTime Date { get; set; }
    }
}
