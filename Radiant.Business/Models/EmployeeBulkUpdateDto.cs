using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models
{
    public class EmployeeBulkUpdateDto
    {
        public List<long> Empids { get; set; }
        public long? ShiftId { get; set; }
        public long? DepartmentId { get; set; }
        public long? SubDepartmentId { get; set; }
        public long? LineId { get; set; }
        public long? StageId { get; set; }
    }
}
