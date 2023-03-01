using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class CurrencyDto
    {
        public CurrencyDto()
        {
            Employee = new HashSet<EmployeeDto>();
            Payroll = new HashSet<PayrollDto>();
        }

        public long Currencyid { get; set; }
        public string Currencyname { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<PayrollDto> Payroll { get; set; }
    }
}
