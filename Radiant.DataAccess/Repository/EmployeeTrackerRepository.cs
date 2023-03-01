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
    public class EmployeeTrackerRepository : IEmployeeTrackerRepository
    {
        private readonly ILogger<EmployeeTracker> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeTrackerRepository(ILogger<EmployeeTracker> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<EmployeeTracker> Create(EmployeeTracker record)
        {
            await _dbContext.EmployeeTracker.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var employeeTracker = await GetById(id);
            employeeTracker.Isactive = false;
            _dbContext.EmployeeTracker.Update(employeeTracker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeTracker> Edit(EmployeeTracker record)
        {
            _dbContext.EmployeeTracker.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }
        public async Task<List<EmployeeTracker>> CreateAll(List<EmployeeTracker> records)
        {
            foreach(var record in records)
            {
                var empTrackers = _dbContext.EmployeeTracker.Where((e) => e.Empid == record.Empid && e.Isactive == true).AsNoTracking().ToList();
                empTrackers.ForEach((et) => et.Isactive = false);
                _dbContext.UpdateRange(empTrackers);
            }
            _dbContext.EmployeeTracker.AddRange(records);
            await _dbContext.SaveChangesAsync();
            return records;
        }
        public async Task<List<EmployeeTracker>> GetAll()
        {
            return await _dbContext.EmployeeTracker.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<EmployeeTracker> GetById(long id)
        {
            return await _dbContext.EmployeeTracker.FirstOrDefaultAsync(x => x.Isactive == true && x.Emptrackerid == id);
        }

        public Task<EmployeeTracker> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
