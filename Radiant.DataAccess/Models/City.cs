using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class City
    {
        public City()
        {
            Employee = new HashSet<Employee>();
        }

        public long Cityid { get; set; }
        public string City1 { get; set; }
        public long? Provinceid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
