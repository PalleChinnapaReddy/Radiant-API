using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models.Reports
{
    public class AttendanceByEmployee
    {
        public long EmpId { get; set; }
        public string Name { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string ShiftDetails { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string PlantLocation { get; set; }
        public string ContractorDetails { get; set; }
        public string LineDescription { get; set; }
        public string StageDescription { get; set; }
        public string IsPresent { get; set; }
    }
}
