using System;

namespace Radiant.Business.Models
{
    public class EmployeeSalaryDto
    {
        public long Employeesalaryid { get; set; }
        public long? Empid { get; set; }
        public double? Basic { get; set; }
        public double? Hra { get; set; }
        public double? Gross { get; set; }
        public DateTime? Effectivefrom { get; set; }
        public DateTime? Effectiveto { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public double? Payperhour { get; set; }
        public double? Pf { get; set; }
        public double? Esic { get; set; }
        public double? Payperday { get; set; }
        public virtual EmployeeDto Emp { get; set; }

    }
}
