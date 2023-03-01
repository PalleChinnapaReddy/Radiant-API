using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class ProvinceDto
    {
        public ProvinceDto()
        {
            City = new HashSet<CityDto>();
            EmployeePermanentcity = new HashSet<EmployeeDto>();
            EmployeePtstate = new HashSet<EmployeeDto>();

        }

        public long Provinceid { get; set; }
        public string Province1 { get; set; }
        public long? Countryid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual CountryDto Country { get; set; }
        public virtual ICollection<CityDto> City { get; set; }
        public virtual ICollection<EmployeeDto> EmployeePermanentcity { get; set; }
        public virtual ICollection<EmployeeDto> EmployeePtstate { get; set; }

    }
}
