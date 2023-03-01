using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IPayrollConfigRepository : IGenericRepository<Payrollconfig>
    {
        Task<List<Payrollconfig>> GetPayrollConfigByMonth(DateTime dateTime);

    }
}
