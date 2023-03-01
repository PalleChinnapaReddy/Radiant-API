using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Attachments
    {
        public Attachments()
        {
            Contractordocuments = new HashSet<Contractordocuments>();
            Employeedocuments = new HashSet<Employeedocuments>();
        }

        public long Attachmentsid { get; set; }
        public string Attachmentsdetails { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Attachmentfor { get; set; }

        public virtual ICollection<Contractordocuments> Contractordocuments { get; set; }
        public virtual ICollection<Employeedocuments> Employeedocuments { get; set; }
    }
}
