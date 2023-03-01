using System;

namespace Radiant.Business.Models
{
    public partial class EmployeeDocumentsDto
    {
        public long Emloyeedocumentsid { get; set; }
        public long? Attachmentid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public long? Empid { get; set; }
        public string[] Employeedocuments1 { get; set; }
        public virtual AttachmentsDto Attachment { get; set; }
        public virtual EmployeeDto Emp { get; set; }
    }
}
