using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.FilterModels
{
    public class ContractorSearchDto
    {
        public ContractorSearchDto()
        {
            this.Page = 1;
        }

        public string ContractorName { get; set; }

        public long ContractorId { get; set; }

        public string ContactPerson { get; set; }

        public int Province { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
