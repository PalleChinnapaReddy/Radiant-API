using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class AbsenceReasonRepository : IGenericRepository<AbsenceReason>
    {
        private readonly ILogger<AbsenceReason> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public AbsenceReasonRepository(ILogger<AbsenceReason> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<AbsenceReason> Create(AbsenceReason record)
        {
            await _dbContext.AbsenceReason.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var absenceReason = await GetById(id);
            absenceReason.Isactive = false;
            _dbContext.AbsenceReason.Update(absenceReason);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AbsenceReason> Edit(AbsenceReason record)
        {
            _dbContext.AbsenceReason.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<AbsenceReason>> GetAll()
        {
            return await _dbContext.AbsenceReason.Where(a => a.Isactive == true)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<AbsenceReason> GetById(long id)
        {
            return await _dbContext.AbsenceReason.FirstOrDefaultAsync(x => x.Absencereasonid == id && x.Isactive ==true);
        }

        public Task<AbsenceReason> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
