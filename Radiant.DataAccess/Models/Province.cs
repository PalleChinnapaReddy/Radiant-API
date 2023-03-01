using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Province
    {
        public Province()
        {
            City = new HashSet<City>();
            EmployeePermanentcity = new HashSet<Employee>();
            EmployeePtstate = new HashSet<Employee>();
        }

        public long Provinceid { get; set; }
        public string Province1 { get; set; }
        public long? Countryid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Employee> EmployeePermanentcity { get; set; }
        public virtual ICollection<Employee> EmployeePtstate { get; set; }
    }
}
