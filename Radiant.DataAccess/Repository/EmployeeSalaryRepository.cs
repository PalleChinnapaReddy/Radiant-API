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
    public class EmployeeSalaryRepository : IGenericRepository<Employeesalary>
    {
        private readonly ILogger<Employeesalary> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeSalaryRepository(ILogger<Employeesalary> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<Employeesalary> Create(Employeesalary record)
        {
            await _dbContext.Employeesalary.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var employeesalary = await GetById(id);
            employeesalary.Isactive = false;
            _dbContext.Employeesalary.Update(employeesalary);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employeesalary> Edit(Employeesalary record)
        {
            _dbContext.Employeesalary.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Employeesalary>> GetAll()
        {
            return await _dbContext.Employeesalary.Where(x => x.Isactive == true).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();
        }

        public async Task<Employeesalary> GetById(long id)
        {
            return await _dbContext.Employeesalary.FirstOrDefaultAsync(x => x.Isactive == true && x.Employeesalaryid == id);
        }

        public Task<Employeesalary> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
