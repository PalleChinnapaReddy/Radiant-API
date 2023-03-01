using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IRadiantHolidayBusiness : IGenericBusiness<RadiantHolidayDto>
    {
        Task<List<RadiantHolidayDto>> CreateHolidays(List<RadiantHolidayDto> holidays);
        Task<RadiantHolidayDto> GetHolidayByDate(DateTime dateTime);
        Task<List<RadiantHolidayDto>> GetAllByHolidayType(RadiantHolidayFilterDto filter
            );
    }
}
