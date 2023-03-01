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
    public class PayrollShiftRepository : IPayrollShiftRepository
    {
        private readonly ILogger<Payrollshift> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public PayrollShiftRepository(ILogger<Payrollshift> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Payrollshift> Create(Payrollshift record)
        {
            await _dbContext.Payrollshift.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var shift = await GetById(id);
            shift.Iscreatedbyhr = false;
            _dbContext.Payrollshift.Update(shift);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Payrollshift> Edit(Payrollshift record)
        {
            _dbContext.Payrollshift.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Payrollshift>> Edit(List<Payrollshift> records)
        {
            _dbContext.Payrollshift.UpdateRange(records);
            await _dbContext.SaveChangesAsync();
            return records;
        }

        public async Task<List<Payrollshift>> GetActiveShiftsByDate(DateTime dateTime)
        {
            return await _dbContext.Payrollshift.Where(s => s.Shiftactivedate == dateTime && s.Isactive == true
            && s.Shift.Shiftactivedate.Value.Date <= dateTime.Date && dateTime.Date <= s.Shift.Shiftinactivedate.Value.Date)
                .OrderByDescending(s => s.CreatedOn)
                .ToListAsync();
        }

        public async Task<List<Payrollshift>> GetActiveShiftsByDateAndShift(DateTime dateTime, long? shiftId)
        {
            return await _dbContext.Payrollshift.Where(s => s.Shiftactivedate == dateTime && s.Shiftid == shiftId && s.Isactive == true 
            && s.Shift.Shiftactivedate.Value.Date <= dateTime.Date && s.Shift.Shiftinactivedate.Value.Date <= dateTime.Date)
                .OrderByDescending(s => s.Payrollshiftid)
                .ToListAsync();
        }

        public async Task<List<Payrollshift>> GetAll()
        {
            return await _dbContext.Payrollshift.Where(s => s.Isactive == true && s.Shift.Isactive == true)
                .OrderByDescending(s => s.CreatedOn)
                .ToListAsync();
        }

        public async Task<Payrollshift> GetById(long id)
        {
            return await _dbContext.Payrollshift.FirstOrDefaultAsync(x => x.Payrollshiftid == id);
        }

        public async Task<Payrollshift> GetByName(string name)
        {
            //return await _dbContext.Payrollshift.AsNoTracking().FirstOrDefaultAsync(x => x.Shiftdetails != null && x.Isactive == true
            //&& x.Shiftdetails.ToLower() == name.ToLower());
            return await _dbContext.Payrollshift.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
