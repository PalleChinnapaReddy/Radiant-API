using System;

namespace Radiant.Business.Models
{
    public class UpsertEmpSalaryDto
    {
        public long? EmpId { get; set; }
        public double? Basic { get; set; }
        public double? HRA { get; set; }
        public double? PayPerHour { get; set; }
        public double? PF { get; set; }
        public double? ESIC { get; set; }
        public double? PayPerDay { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

    }
}
