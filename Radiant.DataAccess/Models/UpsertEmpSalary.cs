using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models
{
    public class UpsertEmpSalary
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
