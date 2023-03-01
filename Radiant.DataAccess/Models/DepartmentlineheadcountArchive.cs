using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class DepartmentlineheadcountArchive
    {
        public long? Departmentlineheadcountid { get; set; }
        public long? Departmentlineid { get; set; }
        public long? Contractorassignedheadcount { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Staffassignedheadcount { get; set; }
        public long? Shiftid { get; set; }
    }
}
