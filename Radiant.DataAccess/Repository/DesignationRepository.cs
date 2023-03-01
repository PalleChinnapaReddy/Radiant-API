using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class DesignationRepository : IGenericRepository<Designation>
    {
        private readonly ILogger<Designation> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public DesignationRepository(ILogger<Designation> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Designation> Create(Designation record)
        {
            await _dbContext.Designation.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var designation = await GetById(id);
            designation.Isactive = false;
            _dbContext.Designation.Update(designation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Designation> Edit(Designation record)
        {
            _dbContext.Designation.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Designation>> GetAll()
        {
            return await _dbContext.Designation.Where(a => a.Isactive == true)
                .OrderByDescending(c => c.Designationdescription)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Designation> GetById(long id)
        {
            return await _dbContext.Designation.FirstOrDefaultAsync(x => x.Designationid == id && x.Isactive == true);
        }

        public Task<Designation> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
