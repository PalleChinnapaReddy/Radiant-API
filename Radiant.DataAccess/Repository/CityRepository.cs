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
    public class CityRepository : ICityRepository
    {
        private readonly ILogger<City> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public CityRepository(ILogger<City> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<City> Create(City record)
        {
            await _dbContext.City.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var city = await GetById(id);
            city.Isactive = false;
            _dbContext.City.Update(city);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<City> Edit(City record)
        {
            _dbContext.City.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<City>> GetAll()
        {
            return await _dbContext.City.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.City1)
                .AsNoTracking().ToListAsync();
        }

        public async Task<City> GetById(long id)
        {
            return await _dbContext.City.FirstOrDefaultAsync(x => x.Isactive == true && x.Cityid == id);
        }
        public async Task<List<City>> GetCitiesByStateId(long stateid)
        {
            return await _dbContext.City
                .Where(x => x.Isactive == true && x.Provinceid == stateid)
                .OrderBy(x=>x.City1)
                .ToListAsync();
        }

        public Task<City> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
