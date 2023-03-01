using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Education
    {
        public Education()
        {
            Employee = new HashSet<Employee>();
        }

        public long Educationid { get; set; }
        public string Educationdetails { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
