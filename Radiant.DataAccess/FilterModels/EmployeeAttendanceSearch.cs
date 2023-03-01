using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class EmployeeAttendanceSearch
    {
        public long? ManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? ShiftId { get; set; }
        public bool? IsPresent { get; set; }
        public bool IsActive { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
