using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.FilterModels
{
    public class ContractorSearch
    {
        public string ContractorName { get; set; }

        public long ContractorId { get; set; }

        public string ContactPerson { get; set; }

        //public string Province { get; set; }
        
        public long ProvinceId { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
