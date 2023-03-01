using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class DepartmentlinemappingArchive
    {
        public long? Departmentlineid { get; set; }
        public long? Parentdepartmentid { get; set; }
        public long? Subdepartmentid { get; set; }
        public long? Lineid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }
}
