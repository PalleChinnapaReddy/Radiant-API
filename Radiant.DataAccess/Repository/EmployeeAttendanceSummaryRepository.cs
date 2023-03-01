using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class EmployeeAttendanceSummaryRepository : IGenericRepository<EmployeeAttendanceSummary>
    {
        private readonly ILogger<EmployeeAttendanceSummary> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeAttendanceSummaryRepository(ILogger<EmployeeAttendanceSummary> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<EmployeeAttendanceSummary> Create(EmployeeAttendanceSummary record)
        {
            await _dbContext.EmployeeAttendanceSummary.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var employeeAttendanceSummary = await GetById(id);
            _dbContext.EmployeeAttendanceSummary.Remove(employeeAttendanceSummary);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeAttendanceSummary> Edit(EmployeeAttendanceSummary record)
        {
            _dbContext.EmployeeAttendanceSummary.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<EmployeeAttendanceSummary>> GetAll()
        {
            return await _dbContext.EmployeeAttendanceSummary
                .OrderByDescending(e=>e.CreatedOn)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EmployeeAttendanceSummary> GetById(long id)
        {
            return await _dbContext.EmployeeAttendanceSummary.FirstOrDefaultAsync(x => x.Employeeattendancesummaryid == id);
        }

        public Task<EmployeeAttendanceSummary> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
