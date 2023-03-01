using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IRadiantHolidayRepository: IGenericRepository<RadiantHoliday>
    {
        Task<List<RadiantHoliday>> CreateHolidays(List<RadiantHoliday> holidays);
        Task<RadiantHoliday> GetHolidayByDate(DateTime dateTime);
        Task<List<RadiantHoliday>> GetAllByHolidayType(RadiantHolidayFilter filter);

    }
}
