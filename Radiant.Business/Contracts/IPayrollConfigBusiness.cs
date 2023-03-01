using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IPayrollConfigBusiness : IGenericBusiness<PayrollConfigDto>
    {
        Task<List<PayrollConfigDto>> GetPayrollConfigByMonth(DateTime dateTime);

    }
}
