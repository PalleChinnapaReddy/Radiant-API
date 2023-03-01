using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class CountryDto
    {
        public CountryDto()
        {
            Employee = new HashSet<EmployeeDto>();
            Province = new HashSet<ProvinceDto>();
        }

        public long Countryid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Country1 { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<ProvinceDto> Province { get; set; }
    }
}
