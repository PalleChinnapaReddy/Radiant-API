using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class AttachmentsDto
    {
        public AttachmentsDto()
        {
            Contractordocuments = new HashSet<ContractordocumentsDto>();
            Employeedocuments = new HashSet<EmployeeDocumentsDto>();
        }
        public long Attachmentsid { get; set; }
        public string Attachmentsdetails { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Attachmentfor { get; set; }
        public virtual ICollection<ContractordocumentsDto> Contractordocuments { get; set; }
        public virtual ICollection<EmployeeDocumentsDto> Employeedocuments { get; set; }
    }
}
