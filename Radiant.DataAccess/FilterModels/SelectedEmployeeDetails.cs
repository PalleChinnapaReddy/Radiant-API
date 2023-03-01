using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class SelectedEmployeeDetails
    {
        public string Name { get; set; }
        public long EmpId { get; set; }
        public long? DepartmentId { get; set; }
        public string Department { get; set; }
        public long? SubDepartmentId { get; set; }
        public string SubDepartment { get; set; }
        public long? LineId { get; set; }
        public string Line { get; set; }

        public long? StageId { get; set; }
        public string Stage { get; set; }
        public int NoOfDaysPresent { get; set; }
        public DateTime DOJ { get; set; }
        public double? PreviousMonthRating { get; set; }
        public bool IsCurrentMonthRatingExists { get; set; }
        public string ImagePath { get; set; }
    }
}
