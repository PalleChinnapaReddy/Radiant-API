using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            ContractorTracker = new HashSet<ContractorTracker>();
            Contractordocuments = new HashSet<Contractordocuments>();
            Employee = new HashSet<Employee>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
        }

        public long Contractorid { get; set; }
        public string Name { get; set; }
        public string Superviorname { get; set; }
        public string Phonenumber { get; set; }
        public string Gst { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CurrentLinemanagerid { get; set; }
        public long? CurrentStagemanagerid { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string Laborlicencenumber { get; set; }
        public string Pfregistrationnumber { get; set; }
        public string Esic { get; set; }
        public string Pan { get; set; }
        public string Peliancesno { get; set; }
        public string Bankname { get; set; }
        public string Accountnumber { get; set; }
        public string Ifsc { get; set; }
        public string Ownerphonenumber { get; set; }
        public string Ownername { get; set; }
        public string Agreementperiod { get; set; }
        public string Vendorname { get; set; }

        public virtual ICollection<ContractorTracker> ContractorTracker { get; set; }
        public virtual ICollection<Contractordocuments> Contractordocuments { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
    }
}
