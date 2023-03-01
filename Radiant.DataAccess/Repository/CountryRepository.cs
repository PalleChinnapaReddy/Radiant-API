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
    public class CountryRepository : IGenericRepository<Country>
    {
        private readonly ILogger<Country> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public CountryRepository(ILogger<Country> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Country> Create(Country record)
        {
            await _dbContext.Country.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var country = await GetById(id);
            country.Isactive = false;
            _dbContext.Country.Update(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Country> Edit(Country record)
        {
            _dbContext.Country.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Country>> GetAll()
        {
            return await _dbContext.Country.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.Country1)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Country> GetById(long id)
        {
            return await _dbContext.Country.FirstOrDefaultAsync(x => x.Isactive == true && x.Countryid == id);
        }

        public Task<Country> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
