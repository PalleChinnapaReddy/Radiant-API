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
    public class CurrencyRepository : IGenericRepository<Currency>
    {
        private readonly ILogger<Currency> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public CurrencyRepository(ILogger<Currency> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Currency> Create(Currency record)
        {
            await _dbContext.Currency.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var currency = await GetById(id);
            currency.Isactive = false;
            _dbContext.Currency.Update(currency);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Currency> Edit(Currency record)
        {
            _dbContext.Currency.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Currency>> GetAll()
        {
            return await _dbContext.Currency.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.Currencyname)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Currency> GetById(long id)
        {
            return await _dbContext.Currency.FirstOrDefaultAsync(x => x.Isactive == true && x.Currencyid == id);
        }

        public Task<Currency> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
