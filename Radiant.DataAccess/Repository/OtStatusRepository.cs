using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class OtStatusRepository : IGenericRepository<OtStatus>
    {
        private readonly ILogger<OtStatus> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public OtStatusRepository(ILogger<OtStatus> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<OtStatus> Create(OtStatus record)
        {
            await _dbContext.OtStatus.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var otStatus = await GetById(id);
            otStatus.Isactive = false;
            _dbContext.OtStatus.Update(otStatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OtStatus> Edit(OtStatus record)
        {
            _dbContext.OtStatus.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<OtStatus>> GetAll()
        {
            return await _dbContext.OtStatus.Where(a => a.Isactive == true)
                .OrderByDescending(ot=>ot.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<OtStatus> GetById(long id)
        {
            return await _dbContext.OtStatus.FirstOrDefaultAsync(x => x.Otstatusid == id && x.Isactive ==true);
        }

        public Task<OtStatus> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
