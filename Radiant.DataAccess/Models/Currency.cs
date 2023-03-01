using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Employee = new HashSet<Employee>();
            Payroll = new HashSet<Payroll>();
        }

        public long Currencyid { get; set; }
        public string Currencyname { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Payroll> Payroll { get; set; }
    }
}
