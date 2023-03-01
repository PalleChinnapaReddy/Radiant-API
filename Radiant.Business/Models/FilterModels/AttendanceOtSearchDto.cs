using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.FilterModels
{
    public class AttendanceOtSearchDto
    {
        public AttendanceOtSearchDto()
        {
            EndDate = DateTime.Now;
            StartDate = EndDate.AddMonths(-1);
            this.PageNumber = 0;
            this.PageSize = int.MaxValue;
        }

        public long? ManagerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
