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
    public class ProvinceRepository : IGenericRepository<Province>
    {
        private readonly ILogger<Province> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public ProvinceRepository(ILogger<Province> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Province> Create(Province record)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Province> Edit( Province record)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Province>> GetAll()
        {
            return await _dbContext.Province.Where(p => p.Isactive == true).OrderBy(p => p.Province1).AsNoTracking().ToListAsync();
        }

        public async Task<Province> GetById(long id)
        {
            return await _dbContext.Province.Where(p => p.Provinceid == id).FirstOrDefaultAsync();
        }

        public Task<Province> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}