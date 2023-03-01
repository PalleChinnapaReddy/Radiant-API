using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class StageRepository : IStageRepository
    {
        private readonly ILogger<Stage> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public StageRepository(ILogger<Stage> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<Stage> Create(Stage record)
        {
            await _dbContext.Stage.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var stage = await GetById(id);
            stage.Isactive = false;
            _dbContext.Stage.Update(stage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Stage> Edit(Stage record)
        {
            _dbContext.Stage.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Stage>> GetAll()
        {
            return await _dbContext.Stage.Where(s => s.Isactive == true)
                .OrderByDescending(s => s.CreatedOn)
                .AsNoTracking()
                .Include(s => s.Line).ToListAsync();
        }

        public async Task<Stage> GetById(long id)
        {
            return await _dbContext.Stage.FirstOrDefaultAsync(s => s.Stageid == id);
        }

        public async Task<Stage> GetByName(string name)
        {
            return await _dbContext.Stage.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Stagedescription != null && s.Stagedescription.ToLower() == name.ToLower());
        }

        public async Task<List<Stage>> GetStageByDeptAndLine(long deptId, long subdeptId, long lineId)
        {
            return await _dbContext.Stage.Where(s => s.Departmentid == deptId && s.Subdepartmentid == subdeptId
            && s.Lineid == lineId && s.Isactive == true).ToListAsync();
        }
        public async Task<List<Stage>> GetStageLine( long lineId)
        {
            return await _dbContext.Stage.Where(s=>s.Lineid == lineId && s.Isactive == true).ToListAsync();
        }
    }
}