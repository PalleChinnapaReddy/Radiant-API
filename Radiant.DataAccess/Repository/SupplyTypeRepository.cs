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
    public class SupplyTypeRepository : IGenericRepository<SupplyType>
    {
        private readonly ILogger<SupplyType> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public SupplyTypeRepository(ILogger<SupplyType> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<SupplyType> Create(SupplyType record)
        {
            await _dbContext.SupplyType.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var supplyType = await GetById(id);
            supplyType.Isactive = false;
            _dbContext.SupplyType.Update(supplyType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SupplyType> Edit(SupplyType record)
        {
            _dbContext.SupplyType.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<SupplyType>> GetAll()
        {
            return await _dbContext.SupplyType.Where(s => s.Isactive == true)
                .OrderBy(st=>st.Typedetails)
                .AsNoTracking().ToListAsync();
        }

        public async Task<SupplyType> GetById(long id)
        {
            return await _dbContext.SupplyType.FirstOrDefaultAsync(x => x.Supplytypeid == id);
        }

        public Task<SupplyType> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
