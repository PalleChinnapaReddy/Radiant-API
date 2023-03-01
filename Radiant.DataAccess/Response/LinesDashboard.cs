using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Response
{
    public class LinesDashboard
    {
        public LinesDashboard()
        {
            Stage = new HashSet<Stage>();
        }
        public long Lineid { get; set; }
        public string Linedescription { get; set; }
        public bool? Isactive { get; set; }
        public long? ActiveEmployeeCount { get; set; }
        public virtual ICollection<Stage> Stage { get; set; }
    }
}
