using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.CustomizedAPI
{
    public class LinesDashboardDto
    {
        public LinesDashboardDto()
        {
            Stage = new HashSet<StageDto>();
        }
        public long Lineid { get; set; }
        public string Linedescription { get; set; }
        public bool? Isactive { get; set; }
        public long? ActiveEmployeeCount { get; set; }
        public virtual ICollection<StageDto> Stage { get; set; }
    }
}
