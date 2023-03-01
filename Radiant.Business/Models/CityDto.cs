using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class CityDto
    {
        public CityDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public long Cityid { get; set; }
        public string City1 { get; set; }
        public long? Provinceid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public virtual ProvinceDto Province { get; set; }
        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
