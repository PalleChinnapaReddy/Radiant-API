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
    public class SsntypeRepository : IGenericRepository<Ssntype>
    {
        private readonly ILogger<Ssntype> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public SsntypeRepository(ILogger<Ssntype> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Ssntype> Create(Ssntype record)
        {
            await _dbContext.Ssntype.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var ssntype = await GetById(id);
            ssntype.Isactive = false;
            _dbContext.Ssntype.Update(ssntype);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ssntype> Edit(Ssntype record)
        {
            _dbContext.Ssntype.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Ssntype>> GetAll()
        {
            return await _dbContext.Ssntype.Where(s => s.Isactive == true)
                .OrderBy(ssn=>ssn.Ssntypedetails)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Ssntype> GetById(long id)
        {
            return await _dbContext.Ssntype.FirstOrDefaultAsync(x => x.Ssntypeid == id);
        }

        public Task<Ssntype> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
