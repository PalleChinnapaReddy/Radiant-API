using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class RadiantHolidayRepository : IRadiantHolidayRepository
    {
        private readonly ILogger<RadiantHoliday> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public RadiantHolidayRepository(ILogger<RadiantHoliday> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<RadiantHoliday> Create(RadiantHoliday record)
        {
            await _dbContext.RadiantHoliday.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<RadiantHoliday>> CreateHolidays(List<RadiantHoliday> holidays)
        {
            await _dbContext.RadiantHoliday.AddRangeAsync(holidays);
            await _dbContext.SaveChangesAsync();
            return holidays;
        }

        public async Task Delete(long id)
        {
            var radiantHoliday = await GetById(id);
            radiantHoliday.Isactive = false;
            _dbContext.RadiantHoliday.Update(radiantHoliday);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RadiantHoliday> Edit(RadiantHoliday record)
        {
            _dbContext.RadiantHoliday.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<RadiantHoliday>> GetAll()
        {
            return await _dbContext.RadiantHoliday
                .Where(r => r.Isactive == true && r.Name.ToLower() != "weekoff" && r.Holiday.Value.Year == DateTime.Now.Year)
                .OrderBy(h => h.Holiday)
                .ToListAsync();
        }

        public async Task<List<RadiantHoliday>> GetAllByHolidayType(RadiantHolidayFilter filterModel)
        {
            if (filterModel.HolidayTypeId == -1)
            {
                return await _dbContext.RadiantHoliday
                    .Where(r => r.Isactive == true && r.Holiday.Value.Year == filterModel.DateTime.Year && r.Holidaytypeid!=3)
                    .OrderBy(h => h.Holiday)
                    .ToListAsync();
            }
            return await _dbContext.RadiantHoliday
                   .Where(r => r.Isactive == true && r.Holiday.Value.Year == filterModel.DateTime.Year 
                   && r.Holidaytypeid == filterModel.HolidayTypeId && r.Holiday.Value.Month == filterModel.DateTime.Month)
                   .OrderBy(h => h.Holiday)
                   .ToListAsync();
        }

        public async Task<RadiantHoliday> GetById(long id)
        {
            return await _dbContext.RadiantHoliday.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Holidayid == id);
        }

        public async Task<RadiantHoliday> GetByName(string name)
        {
            return await _dbContext.RadiantHoliday.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name != null && x.Name.ToLower() == name.ToLower());
        }

        public async Task<RadiantHoliday> GetHolidayByDate(DateTime dateTime)
        {
            return await _dbContext.RadiantHoliday.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Holiday != null && x.Holiday == dateTime && x.Isactive == true);
        }
    }
}
