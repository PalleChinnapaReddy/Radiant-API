using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public class EmployeeBulkEditModel
    {
        public EmployeeBulkEditModel()
        {
            this.Empids = new List<long>();
        }

        public List<long> Empids { get; set; }
        public long? ShiftId { get; set; }
        public long? DepartmentId { get; set; }
        public long? SubDepartmentId { get; set; }
        public long? LineId { get; set; }
        public long? StageId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public long? ManagerId { get; set; }
        public bool? Il { get; set; }
    }
}
