using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class ContractorRepository : ISearchableRepository<Contractor, ContractorSearch>
    {
        private readonly ILogger<Contractor> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public ContractorRepository(ILogger<Contractor> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Contractor> Create(Contractor record)
        {
            await _dbContext.Contractor.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var contractor = await GetById(id);
            contractor.Isactive = false;
            _dbContext.Contractor.Update(contractor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Contractor> Edit(Contractor record)
        {
            _dbContext.Contractor.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Contractor>> GetAll()
        {
            return await _dbContext.Contractor.Where(c => c.Isactive == true).AsNoTracking()
                .Include(c=>c.Contractordocuments).ThenInclude(cd=>cd.Attachment)
                .OrderByDescending(c=>c.CreatedOn)
                .ToListAsync();
        }

        public async Task<Contractor> GetById(long id)
        {
            return await _dbContext.Contractor
                .Where(c => c.Isactive == true).Include(c=>c.Contractordocuments)
                .FirstOrDefaultAsync(x => x.Contractorid == id);
        }

        public Task<Contractor> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contractor>> Search(ContractorSearch searchCriteria)
        {
            //Assuming that Minimum value of Page is 1
            return await _dbContext.Contractor.AsNoTracking()
                .Where(c => c.Isactive == true &&
                 (searchCriteria.ContractorId == 0 || c.Contractorid == searchCriteria.ContractorId) &&
                 (searchCriteria.ProvinceId == 0) &&
                 (string.IsNullOrWhiteSpace(searchCriteria.ContractorName) || c.Name.Contains(searchCriteria.ContractorName, StringComparison.InvariantCultureIgnoreCase)) &&
                 (string.IsNullOrWhiteSpace(searchCriteria.ContactPerson) || c.Superviorname.Contains(searchCriteria.ContactPerson, StringComparison.InvariantCultureIgnoreCase)))
                .Skip((searchCriteria.Page - 1) * searchCriteria.Size).Take(searchCriteria.Size)
                .Include(c => c.Contractordocuments).ThenInclude(cd => cd.Attachment)
                .ToListAsync();
        }
    }
}