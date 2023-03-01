using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IShiftBusiness : IGenericBusiness<ShiftDto>
    {
        Task<List<ShiftDto>> GetActiveShiftsByDate(DateTime dateTime);
    }
}
