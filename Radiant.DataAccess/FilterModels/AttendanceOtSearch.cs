using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class AttendanceOtSearch
    {
        public long? ManagerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
