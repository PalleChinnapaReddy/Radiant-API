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
    public class EmployeeRoleTrackerRepository : IGenericRepository<EmployeeRoleTracker>
    {
        private readonly ILogger<EmployeeRoleTracker> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeRoleTrackerRepository(ILogger<EmployeeRoleTracker> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<EmployeeRoleTracker> Create(EmployeeRoleTracker record)
        {
            await _dbContext.EmployeeRoleTracker.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var employeeRoleTracker = await GetById(id);
            employeeRoleTracker.Isactive = false;
            _dbContext.EmployeeRoleTracker.Update(employeeRoleTracker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeRoleTracker> Edit(EmployeeRoleTracker record)
        {
            _dbContext.EmployeeRoleTracker.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<EmployeeRoleTracker>> GetAll()
        {
            return await _dbContext.EmployeeRoleTracker.Where(x => x.Isactive == true).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();
        }

        public async Task<EmployeeRoleTracker> GetById(long id)
        {
            return await _dbContext.EmployeeRoleTracker.FirstOrDefaultAsync(x => x.Isactive == true && x.Emproletrackerid == id);
        }

        public Task<EmployeeRoleTracker> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
