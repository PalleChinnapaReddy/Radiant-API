using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Ssntype
    {
        public Ssntype()
        {
            Employee = new HashSet<Employee>();
        }

        public long Ssntypeid { get; set; }
        public string Ssntypedetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
