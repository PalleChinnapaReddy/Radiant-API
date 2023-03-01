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
    public class PayrollConfigRepository : IPayrollConfigRepository
    {
        private readonly ILogger<Payrollconfig> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public PayrollConfigRepository(ILogger<Payrollconfig> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Payrollconfig> Create(Payrollconfig record)
        {
            record.Payrollstatusid = 1;
            await _dbContext.Payrollconfig.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var payrollconfig = await GetById(id);
            payrollconfig.Isactive = false;
            payrollconfig.Payrollstatusid = 5;
            _dbContext.Payrollconfig.Update(payrollconfig);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Payrollconfig> Edit(Payrollconfig record)
        {
            _dbContext.Payrollconfig.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Payrollconfig>> GetAll()
        {
            return await _dbContext.Payrollconfig.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.Payrollconfigid)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Payrollconfig> GetById(long id)
        {
            return await _dbContext.Payrollconfig.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Isactive == true && x.Payrollconfigid == id);
        }

        public Task<Payrollconfig> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Payrollconfig>> GetPayrollConfigByMonth(DateTime dateTime)
        {
            return await _dbContext.Payrollconfig.
                Where(x => x.Isactive == true && 
                x.UpdatedOn.Year==dateTime.Year && x.Payrollstatusid != 5)
                .OrderByDescending(c => c.Payrollconfigid)
                .AsNoTracking().ToListAsync();
        }
    }
}

