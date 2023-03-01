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
    public class ShiftRepository : IShiftRepository
    {
        private readonly ILogger<Shift> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public ShiftRepository(ILogger<Shift> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Shift> Create(Shift record)
        {
            await _dbContext.Shift.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var shift = await GetById(id);
            shift.Isactive = false;
            shift.Shiftinactivedate = DateTime.Now.Date;
            _dbContext.Shift.Update(shift);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Shift> Edit(Shift record)
        {
            _dbContext.Shift.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Shift>> GetActiveShiftsByDate(DateTime dateTime)
        {
            return await _dbContext.Shift.Where(s => s.Shiftactivedate <= dateTime && dateTime <= s.Shiftinactivedate)
                .OrderByDescending(s => s.CreatedOn)
                .Include(s => s.Employee).AsNoTracking().ToListAsync();
        }

        public async Task<List<Shift>> GetAll()
        {
            return await _dbContext.Shift.Where(s => s.Isactive == true)
                .OrderByDescending(s => s.CreatedOn)
                .Include(s => s.Employee).AsNoTracking().ToListAsync();
        }

        public async Task<Shift> GetById(long id)
        {
            return await _dbContext.Shift.FirstOrDefaultAsync(x => x.Shiftid == id);
        }

        public async Task<Shift> GetByName(string name)
        {
            return await _dbContext.Shift.AsNoTracking().FirstOrDefaultAsync(x => x.Shiftdetails != null && x.Isactive == true
            && x.Shiftdetails.ToLower() == name.ToLower());
        }
    }
}
