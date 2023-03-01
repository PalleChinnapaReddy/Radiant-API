using System;

namespace Radiant.Business.Models.FilterModels
{
    public class EmployeeLinesDashboardSearchDto
    {
        public EmployeeLinesDashboardSearchDto()
        {
            CurrentDate = DateTime.Now;
        }

        public long? ManagerId { get; set; }
        public long? LineId { get; set; }
        public long? StageId { get; set; }
        public long? ShiftId { get; set; }
        public DateTime? CurrentDate { get; set; }
        public bool? IsPresent { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
