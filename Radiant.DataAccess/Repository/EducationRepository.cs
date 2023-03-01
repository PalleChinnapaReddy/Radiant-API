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
    public class EducationRepository : IGenericRepository<Education>
    {
        private readonly ILogger<Education> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EducationRepository(ILogger<Education> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Education> Create(Education record)
        {
            await _dbContext.Education.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var education = await GetById(id);
            education.Isactive = false;
            _dbContext.Education.Update(education);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Education> Edit(Education record)
        {
            _dbContext.Education.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Education>> GetAll()
        {
            return await _dbContext.Education.Where(e => e.Isactive == true)
                .OrderByDescending(c => c.Educationdetails)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Education> GetById(long id)
        {
            return await _dbContext.Education.FirstOrDefaultAsync(x => x.Educationid == id);
        }

        public Task<Education> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}