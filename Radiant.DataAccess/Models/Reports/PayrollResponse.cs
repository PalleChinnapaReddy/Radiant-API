using System.Collections.Generic;

namespace Radiant.DataAccess.Models.Reports
{
    public class PayrollResponse
    {
        public long? TotalRows { get; set; }
        public List<Payroll> Payrolls { get; set; }
    }
}
