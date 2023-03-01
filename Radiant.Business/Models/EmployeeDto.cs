using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            EmployeeAttendance = new HashSet<EmployeeAttendanceDto>();
            EmployeeRoleTracker = new HashSet<EmployeeRoleTrackerDto>();
            EmployeeTracker = new HashSet<EmployeeTrackerDto>();
            Employeedocuments = new HashSet<EmployeeDocumentsDto>();
            InverseCurrentLinemanager = new HashSet<EmployeeDto>();
            InverseCurrentStagemanager = new HashSet<EmployeeDto>();
            Payroll = new HashSet<PayrollDto>();
            Employeeskill = new HashSet<EmployeeSkillDto>();
            Employeesalary = new HashSet<EmployeeSalaryDto>();
            Payrolldeduction = new HashSet<PayrolldeductionDto>();
            //PayrollOld = new HashSet<PayrollOld>();
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
        public bool Lwfapplicable { get; set; }
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

        public virtual CompanyDto Company { get; set; }
        public virtual CurrencyDto Currency { get; set; }
        public virtual ContractorDto CurrentContractor { get; set; }
        public virtual DepartmentDto CurrentDepartment { get; set; }
        public virtual DesignationDto CurrentDesignation { get; set; }
        public virtual LineDto CurrentLine { get; set; }
        public virtual EmployeeDto CurrentLinemanager { get; set; }
        public virtual PlantDto CurrentPlant { get; set; }
        public virtual RoleDto CurrentRole { get; set; }
        public virtual ShiftDto CurrentShift { get; set; }
        public virtual StageDto CurrentStage { get; set; }
        public virtual EmployeeDto CurrentStagemanager { get; set; }
        public virtual EducationDto Education { get; set; }
        public virtual SupplyTypeDto Employmenttype { get; set; }
        public virtual GenderDto Gender { get; set; }
        public virtual MaritalstatusDto Maritalstatus { get; set; }
        public virtual CountryDto Nation { get; set; }
        public virtual PaymenttypeDto Paymenttype { get; set; }
        public virtual ProvinceDto Permanentcity { get; set; }

        public virtual CityDto Presentcity { get; set; }
        public virtual ProvinceDto Ptstate { get; set; }
        public virtual SsntypeDto Ssntype { get; set; }
        public virtual DepartmentDto Subdepartment { get; set; }
        public virtual ICollection<EmployeeAttendanceDto> EmployeeAttendance { get; set; }
        public virtual ICollection<EmployeeRoleTrackerDto> EmployeeRoleTracker { get; set; }
        public virtual ICollection<EmployeeTrackerDto> EmployeeTracker { get; set; }
        public virtual ICollection<EmployeeDocumentsDto> Employeedocuments { get; set; }
        public virtual ICollection<EmployeeDto> InverseCurrentLinemanager { get; set; }
        public virtual ICollection<EmployeeDto> InverseCurrentStagemanager { get; set; }
        public virtual ICollection<PayrollDto> Payroll { get; set; }
        public virtual ICollection<EmployeeSkillDto> Employeeskill { get; set; }
        public virtual ICollection<EmployeeSalaryDto> Employeesalary { get; set; }

        //public virtual ICollection<PayrollOld> PayrollOld { get; set; }
        public virtual ICollection<PayrolldeductionDto> Payrolldeduction { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is EmployeeDto)
            {
                return this.Empcode == ((EmployeeDto)obj).Empcode;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Empcode.GetHashCode();
        }

    }
}
