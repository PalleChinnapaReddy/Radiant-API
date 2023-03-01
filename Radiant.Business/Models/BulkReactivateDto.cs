using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models
{
    public class BulkReactivateDto
    {
        public List<long> Empids { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }
}
