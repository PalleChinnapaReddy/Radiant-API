using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Maritalstatus
    {
        public Maritalstatus()
        {
            Employee = new HashSet<Employee>();
        }

        public long Maritalstatusid { get; set; }
        public string Maritalstatus1 { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
