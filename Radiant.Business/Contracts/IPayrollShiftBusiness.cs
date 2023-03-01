using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IPayrollShiftBusiness : IGenericBusiness<PayrollshiftDto>
    {
        Task<List<PayrollshiftDto>> GetActiveShiftsByDateAndShift(DateTime dateTime, long? shiftId);
        Task<List<PayrollshiftDto>> GetActiveShiftsByDate(DateTime dateTime);
        Task<List<PayrollshiftDto>> Edit(List<PayrollshiftDto> shifts);

    }
}
