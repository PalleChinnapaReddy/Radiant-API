using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Employeeskill
    {
        public long Employeeskillid { get; set; }
        public long? Empid { get; set; }
        public DateTime Ratingdate { get; set; }
        public double? Operatorerrors { get; set; }
        public double? Lineleaderrating { get; set; }
        public double? Attendancescore { get; set; }
        public double? Otherscore { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public double? Skillratingscore { get; set; }
        public double? Lineleaderscore { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
