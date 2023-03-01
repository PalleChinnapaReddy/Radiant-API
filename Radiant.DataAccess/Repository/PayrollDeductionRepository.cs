using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class PayrollDeductionRepository : IPayrollDeductionRepository
    {
        private readonly ILogger<Payrolldeduction> _logger;
        private readonly CustomRadiantDbContext _dbContext;
        public PayrollDeductionRepository(ILogger<Payrolldeduction> logger
            , CustomRadiantDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Payrolldeduction> Create(Payrolldeduction record)
        {
            await _dbContext.Payrolldeduction.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var payroll = await GetById(id);
            payroll.Isactive = false;
            _dbContext.Payrolldeduction.Update(payroll);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Payrolldeduction> Edit(Payrolldeduction record)
        {
            _dbContext.Payrolldeduction.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Payrolldeduction>> GetAll()
        {
            return await _dbContext.Payrolldeduction
                .Where(p => p.Isactive == true)
                .OrderByDescending(p => p.CreatedOn)
                .AsNoTracking().ToListAsync();

        }

        public async Task<Payrolldeduction> GetById(long id)
        {
            return await _dbContext.Payrolldeduction
                .FirstOrDefaultAsync(x => x.Pdid == id);
        }

        public Task<Payrolldeduction> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UploadEmployeeDeduction(List<Payrolldeduction> payrolldeductions)
        {
            var fpd = payrolldeductions.FirstOrDefault();
            // Delete rows with the courrent month and year

            var pds = await _dbContext.Payrolldeduction.Where(pd => pd.Month == fpd.Month && pd.Year == fpd.Year).ToListAsync();
            _dbContext.Payrolldeduction.RemoveRange(pds);
            await _dbContext.SaveChangesAsync();
            //Insert rows now
            await _dbContext.Payrolldeduction.AddRangeAsync(payrolldeductions);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}