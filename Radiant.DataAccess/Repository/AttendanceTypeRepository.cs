using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class AttendanceTypeRepository : IGenericRepository<Attendancetype>
    {
        private readonly ILogger<Attendancetype> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public AttendanceTypeRepository(ILogger<Attendancetype> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Attendancetype> Create(Attendancetype record)
        {
            await _dbContext.Attendancetype.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var attendanceType = await GetById(id);
            attendanceType.Isactive = false;
            _dbContext.Attendancetype.Update(attendanceType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Attendancetype> Edit(Attendancetype record)
        {
            _dbContext.Attendancetype.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Attendancetype>> GetAll()
        {
            return await _dbContext.Attendancetype
                .Where(a => a.Isactive == true)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Attendancetype> GetById(long id)
        {
            return await _dbContext.Attendancetype.FirstOrDefaultAsync(x => x.Id == id && x.Isactive ==true);
        }

        public Task<Attendancetype> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
