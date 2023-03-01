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
    public class ContractorTrackerRepository : IGenericRepository<ContractorTracker>
    {
        private readonly ILogger<ContractorTracker> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public ContractorTrackerRepository(ILogger<ContractorTracker> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<ContractorTracker> Create(ContractorTracker record)
        {
            await _dbContext.ContractorTracker.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var contractorTracker = await GetById(id);
            contractorTracker.Isactive = false;
            _dbContext.ContractorTracker.Update(contractorTracker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ContractorTracker> Edit(ContractorTracker record)
        {
            _dbContext.ContractorTracker.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<ContractorTracker>> GetAll()
        {
            return await _dbContext.ContractorTracker.Where(a => a.Isactive == true)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<ContractorTracker> GetById(long id)
        {
            return await _dbContext.ContractorTracker.FirstOrDefaultAsync(x => x.Contactortrackerid == id && x.Isactive == true);
        }

        public Task<ContractorTracker> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
