using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class PlantRepository : IGenericRepository<Plant>
    {
        private readonly ILogger<Plant> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public PlantRepository(ILogger<Plant> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Plant> Create(Plant record)
        {
            await _dbContext.Plant.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var plant = await GetById(id);
            plant.Isactive = false;
            _dbContext.Plant.Update(plant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Plant> Edit(Plant record)
        {
            _dbContext.Plant.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Plant>> GetAll()
        {
            return await _dbContext.Plant.Where(p => p.Isactive == true)
                .OrderByDescending(p=>p.Plantdescription)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Plant> GetById(long id)
        {
            return await _dbContext.Plant.FirstOrDefaultAsync(x => x.Plantid == id);
        }

        public Task<Plant> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
