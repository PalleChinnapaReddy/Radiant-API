using System.Collections.Generic;

namespace Radiant.Business.Models.Response
{
    public class PayrollResponseDto
    {
        public long? TotalRows { get; set; }
        public List<PayrollDto> Payrolls { get; set; }
    }
}
