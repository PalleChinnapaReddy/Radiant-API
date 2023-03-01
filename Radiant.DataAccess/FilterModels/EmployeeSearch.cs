using System;

namespace Radiant.DataAccess.FilterModels
{
    public class EmployeeSearch
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Genderid { get; set; }
        public DateTime? Dob { get; set; }
        public string Phonenumber { get; set; }
        public long? Permanentcityid { get; set; }
        public long? EmpCode { get; set; }
        public long? EmpId { get; set; }
        public long? Educationid { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Presentzip { get; set; }
        public DateTime? Dateofjoining { get; set; }
        public long? CurrentRoleid { get; set; }
        public long? CurrentContractorid { get; set; }
        public long? CurrentPlantid { get; set; }
        public long? CurrentDepartmentid { get; set; }
        public bool IsDepartmentNull { get; set; }
        public long? Subdepartmentid { get; set; }
        public bool IsSubDepartmetnNull { get; set; }
        public long? CurrentLineid { get; set; }
        public bool IsLineNull { get; set; }
        public long? CurrentLinemanagerid { get; set; }
        public long? CurrentStageid { get; set; }
        public long? CurrentShiftid { get; set; }
        public bool IsShiftNull { get; set; }
        public double? Payperhour { get; set; }
        public long? Ssntypeid { get; set; }
        public string Ssn { get; set; }
        public string Bankname { get; set; }
        public string Ifsc { get; set; }
        public string Accountnumber { get; set; }
        public string Esic { get; set; }
        public string Uan { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
        public bool Status { get; set; }

    }
}
