using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Company
    {
        public Company()
        {
            Employee = new HashSet<Employee>();
        }

        public long Companyid { get; set; }
        public string Company1 { get; set; }
        public string Location { get; set; }
        public string Branch { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
