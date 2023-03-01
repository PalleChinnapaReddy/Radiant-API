using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IPayrollShiftRepository : IGenericRepository<Payrollshift>
    {
        Task<List<Payrollshift>> GetActiveShiftsByDateAndShift(DateTime dateTime,long? shiftId);
        Task<List<Payrollshift>> GetActiveShiftsByDate(DateTime dateTime);
        Task<List<Payrollshift>> Edit(List<Payrollshift> shifts);

    }
}
