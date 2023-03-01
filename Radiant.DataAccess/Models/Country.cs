using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Country
    {
        public Country()
        {
            Employee = new HashSet<Employee>();
            Province = new HashSet<Province>();
        }

        public long Countryid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Country1 { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Province> Province { get; set; }
    }
}
