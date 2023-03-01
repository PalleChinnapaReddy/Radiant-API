﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.Reports
{
    public class AttendanceByEmployeeFilterDto
    {
        public int ContractorId { get; set; }

        public int LineId { get; set; }

        public int StageId { get; set; }

        public int PlantId { get; set; }

        public int EmpId { get; set; }

        public string ShiftIds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
