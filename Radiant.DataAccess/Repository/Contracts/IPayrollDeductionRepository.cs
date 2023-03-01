using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IPayrollDeductionRepository : IGenericRepository<Payrolldeduction>
    {
        Task<bool> UploadEmployeeDeduction(List<Payrolldeduction> payrolldeductions);
    }
}
