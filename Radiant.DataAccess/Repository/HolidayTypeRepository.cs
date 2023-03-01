using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class HolidayTypeRepository: IGenericRepository<Holidaytype>
    {
        private readonly ILogger<Role> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public HolidayTypeRepository(ILogger<Role> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Holidaytype> Create(Holidaytype record)
        {
            await _dbContext.Holidaytype.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var holidaytype = await GetById(id);
            holidaytype.Isactive = false;
            _dbContext.Holidaytype.Update(holidaytype);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Holidaytype> Edit(Holidaytype record)
        {
            _dbContext.Holidaytype.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Holidaytype>> GetAll()
        {
            return await _dbContext.Holidaytype.Where(r => r.Isactive == true)
                .OrderBy(r => r.Holidaytypedetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Holidaytype> GetById(long id)
        {
            return await _dbContext.Holidaytype.FirstOrDefaultAsync(x => x.Holidaytypeid == id);
        }

        public async Task<Holidaytype> GetByName(string name)
        {
            return await _dbContext.Holidaytype.AsNoTracking().FirstOrDefaultAsync(x => x.Holidaytypedetails.ToLower() == name.ToLower());
        }
    }
}
