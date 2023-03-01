﻿using System;

namespace Radiant.DataAccess.Models.Reports
{
    public class PayrollFilter
    {
        public PayrollFilter()
        {
            PageNumber = 0;
            PageSize = 500;
        }
        public DateTime? PayrollDate { get; set; }
        public long? DepartmentId { get; set; }
        public long? ContractorId { get; set; }
        public long? LineId { get; set; }
        public long? ManagerId { get; set; }
        public long? ShiftId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
