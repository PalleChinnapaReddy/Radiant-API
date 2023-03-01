using Radiant.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IPayrollDeductionBusiness:IGenericBusiness<PayrolldeductionDto>
    {
        Task<bool> UploadEmployeeDeduction(List<PayrolldeductionDto> payrolldeductions);
    }
}
