using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Contractordocuments
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

        public virtual Attachments Attachment { get; set; }
        public virtual Contractor Contractor { get; set; }
    }
}
