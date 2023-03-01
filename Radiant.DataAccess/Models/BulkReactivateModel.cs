using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Models
{
    public class BulkReactivateModel
    {
        public List<long> Empids { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }
}
