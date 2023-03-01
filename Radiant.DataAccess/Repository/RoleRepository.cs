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
    public class RoleRepository : IGenericRepository<Role>
    {
        private readonly ILogger<Role> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public RoleRepository(ILogger<Role> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Role> Create(Role record)
        {
            await _dbContext.Role.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var role = await GetById(id);
            role.Isactive = false;
            _dbContext.Role.Update(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> Edit(Role record)
        {
            _dbContext.Role.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _dbContext.Role.Where(r => r.Isactive == true)
                .OrderBy(r=>r.Roledetails)
                .AsNoTracking()
                //.Include((r)=>r.Employee).ThenInclude(e=>e.EmployeeAttendance)
                .ToListAsync();
        }

        public async Task<Role> GetById(long id)
        {
            return await _dbContext.Role.FirstOrDefaultAsync(x => x.Roleid == id);
        }

        public async Task<Role> GetByName(string name)
        {
            return await _dbContext.Role.AsNoTracking().FirstOrDefaultAsync(x => x.Roledetails.ToLower() == name.ToLower());
        }
    }
}
