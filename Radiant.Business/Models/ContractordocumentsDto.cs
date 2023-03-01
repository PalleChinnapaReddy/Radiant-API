using System;

namespace Radiant.Business.Models
{
    public partial class ContractordocumentsDto
    {
        public long Contractordocumentsid { get; set; }
        public long? Attachmentid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Contractorid { get; set; }
        public string[] Contractordocuments1 { get; set; }

        public virtual AttachmentsDto Attachment { get; set; }
        public virtual ContractorDto Contractor { get; set; }
    }
}
