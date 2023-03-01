using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class ScreensRepository : IScreensRepository
    {
        private readonly ILogger<Screens> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public ScreensRepository(ILogger<Screens> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Screens> Create(Screens record)
        {
            await _dbContext.Screens.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var screen = await GetById(id);
            screen.Isactive = false;
            _dbContext.Screens.Update(screen);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Screens> Edit(Screens record)
        {
            _dbContext.Screens.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Screens>> GetAll()
        {
            return await _dbContext.Screens.Where(r => r.Isactive == true)
                .OrderBy(s=>s.Name)
                .ToListAsync();
        }

        public async Task<Screens> GetById(long id)
        {
            return await _dbContext.Screens.FirstOrDefaultAsync(x => x.Screenid == id);
        }

        public Task<Screens> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Screens>> GetScreensByIds(List<long> Ids)
        {
            return await _dbContext.Screens.Where(r => r.Isactive == true && Ids.Contains(r.Screenid)).ToListAsync();
        }
    }
}
