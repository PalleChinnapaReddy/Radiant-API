using System;

namespace Radiant.Business.Models.FilterModels
{
    public class EmployeeAttendanceSearchDto
    {
        public EmployeeAttendanceSearchDto()
        {
            EndDate = DateTime.Now;
            StartDate = EndDate.AddDays(-7);
            this.IsActive = true;
            this.PageNumber = 0;
            this.PageSize = int.MaxValue;
        }
        public long? ManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public long? ShiftId { get; set; }
        public bool? IsPresent { get; set; }
        public bool IsActive { get; set; }
        public DateTime EndDate { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
