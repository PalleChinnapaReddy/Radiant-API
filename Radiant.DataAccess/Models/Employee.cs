using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendance>();
            EmployeeRoleTracker = new HashSet<EmployeeRoleTracker>();
            EmployeeTracker = new HashSet<EmployeeTracker>();
            Employeedocuments = new HashSet<Employeedocuments>();
            Employeesalary = new HashSet<Employeesalary>();
            Employeeskill = new HashSet<Employeeskill>();
            InverseCurrentLinemanager = new HashSet<Employee>();
            InverseCurrentStagemanager = new HashSet<Employee>();
            Payroll = new HashSet<Payroll>();
            Payrolldeduction = new HashSet<Payrolldeduction>();
        }

        public long Empid { get; set; }
        public DateTime? Dob { get; set; }
        public long? Genderid { get; set; }
        public string Phonenumber { get; set; }
        public long? Ssntypeid { get; set; }
        public string Ssn { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CurrentLinemanagerid { get; set; }
        public long? CurrentStagemanagerid { get; set; }
        public long? CurrentContractorid { get; set; }
        public long? CurrentShiftid { get; set; }
        public long? CurrentRoleid { get; set; }
        public long? CurrentLineid { get; set; }
        public long? CurrentStageid { get; set; }
        public long? Permanentcityid { get; set; }
        public string Presentzip { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public double? Payperhour { get; set; }
        public long? CurrentDepartmentid { get; set; }
        public long? Currencyid { get; set; }
        public long? CurrentPlantid { get; set; }
        public DateTime Dateofjoining { get; set; }
        public long? Educationid { get; set; }
        public string Uan { get; set; }
        public string Esic { get; set; }
        public string Bankname { get; set; }
        public string Accountnumber { get; set; }
        public string Ifsc { get; set; }
        public string Password { get; set; }
        public string Fathername { get; set; }
        public long? Subdepartmentid { get; set; }
        public DateTime Dateofleaving { get; set; }
        public long? Empcode { get; set; }
        public long? Presentcityid { get; set; }
        public bool? Ildl { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Salutation { get; set; }
        public DateTime? Dateofconfirmation { get; set; }
        public string Status { get; set; }
        public long? Paymenttypeid { get; set; }
        public string Officialemailaddress { get; set; }
        public bool? Pfapplicable { get; set; }
        public bool? Esicapplicable { get; set; }
        public bool? Ptapplicable { get; set; }
        public long? Ptstateid { get; set; }
        public bool? Lwfapplicable { get; set; }
        public string Physicalstatus { get; set; }
        public long? Employmenttypeid { get; set; }
        public DateTime? Dateofprobation { get; set; }
        public string Bankbranch { get; set; }
        public DateTime? Dateofmarriage { get; set; }
        public string Bloodgroup { get; set; }
        public string Lmsreportingmanager1 { get; set; }
        public string Lmsreportingmanager2 { get; set; }
        public string Lmsreportingmanager3 { get; set; }
        public string Tnareportingmanager { get; set; }
        public string Wagescode { get; set; }
        public long? Maritalstatusid { get; set; }
        public string Spousename { get; set; }
        public string Personalemailaddress { get; set; }
        public bool? Ispanaadhaarlinked { get; set; }
        public DateTime? Dateofresignation { get; set; }
        public DateTime? Dateoflettersubmission { get; set; }
        public string Reason { get; set; }
        public string Remarksforfnf { get; set; }
        public string Cardcode { get; set; }
        public string Groupdoj { get; set; }
        public string OldEmployeecode { get; set; }
        public string Attendancemode { get; set; }
        public string Religion { get; set; }
        public string Visauidnumber { get; set; }
        public string Ibannumber { get; set; }
        public string Visacountry { get; set; }
        public string Caste { get; set; }
        public string Alternatemobileno { get; set; }
        public string Residentialnumber { get; set; }
        public string Professiontaxstate { get; set; }
        public string Grade { get; set; }
        public long? CurrentDesignationid { get; set; }
        public long? Companyid { get; set; }
        public string Band { get; set; }
        public string Portal { get; set; }
        public string Permanentzip { get; set; }
        public long? Nationid { get; set; }
        public string Qualification { get; set; }
        public bool? IsEligibleForRehire { get; set; }
        public string LeavingReason { get; set; }
        public string CommentsOnEmployeeReliving { get; set; }
        public bool? IsRehired { get; set; }
        public long? PreviousEmployeeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Contractor CurrentContractor { get; set; }
        public virtual Department CurrentDepartment { get; set; }
        public virtual Designation CurrentDesignation { get; set; }
        public virtual Line CurrentLine { get; set; }
        public virtual Employee CurrentLinemanager { get; set; }
        public virtual Plant CurrentPlant { get; set; }
        public virtual Role CurrentRole { get; set; }
        public virtual Shift CurrentShift { get; set; }
        public virtual Stage CurrentStage { get; set; }
        public virtual Employee CurrentStagemanager { get; set; }
        public virtual Education Education { get; set; }
        public virtual SupplyType Employmenttype { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Maritalstatus Maritalstatus { get; set; }
        public virtual Country Nation { get; set; }
        public virtual Paymenttype Paymenttype { get; set; }
        public virtual Province Permanentcity { get; set; }
        public virtual City Presentcity { get; set; }
        public virtual Province Ptstate { get; set; }
        public virtual Ssntype Ssntype { get; set; }
        public virtual Department Subdepartment { get; set; }
        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual ICollection<EmployeeRoleTracker> EmployeeRoleTracker { get; set; }
        public virtual ICollection<EmployeeTracker> EmployeeTracker { get; set; }
        public virtual ICollection<Employeedocuments> Employeedocuments { get; set; }
        public virtual ICollection<Employeesalary> Employeesalary { get; set; }
        public virtual ICollection<Employeeskill> Employeeskill { get; set; }
        public virtual ICollection<Employee> InverseCurrentLinemanager { get; set; }
        public virtual ICollection<Employee> InverseCurrentStagemanager { get; set; }
        public virtual ICollection<Payroll> Payroll { get; set; }
        public virtual ICollection<Payrolldeduction> Payrolldeduction { get; set; }
    }
}
