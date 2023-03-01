using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public long Designationid { get; set; }
        public string Designationdescription { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
