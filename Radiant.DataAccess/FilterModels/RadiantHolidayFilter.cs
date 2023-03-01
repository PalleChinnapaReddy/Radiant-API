using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class RadiantHolidayFilter
    {
        public DateTime DateTime { get; set; }
        public long? HolidayTypeId { get; set; }
    }
}
