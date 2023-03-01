using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class GenderDto
    {
        public GenderDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public long Genderid { get; set; }
        public string Genderdescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
