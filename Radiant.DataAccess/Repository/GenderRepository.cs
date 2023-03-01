using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class GenderRepository : IGenericRepository<Gender>
    {
        private readonly ILogger<Gender> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public GenderRepository(ILogger<Gender> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Gender> Create(Gender record)
        {
            await _dbContext.Gender.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var gender = await GetById(id);
            gender.Isactive = false;
            _dbContext.Gender.Update(gender);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Gender> Edit(Gender record)
        {
            _dbContext.Gender.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Gender>> GetAll()
        {
            return await _dbContext.Gender.Where(g => g.Isactive == true).OrderByDescending(c => c.Genderdescription).AsNoTracking().ToListAsync();
        }

        public async Task<Gender> GetById(long id)
        {
            return await _dbContext.Gender.FirstOrDefaultAsync(x => x.Genderid == id);
        }

        public Task<Gender> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
