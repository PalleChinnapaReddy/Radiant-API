using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class EmployeeAttendanceRefreshRepository : IEmployeeAttendanceRefreshRepository
    {
        private readonly ILogger<Employeeattendancerefresh> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeAttendanceRefreshRepository(ILogger<Employeeattendancerefresh> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> RefreshPostGreAttendance(List<Employeeattendancerefresh> employeeattendancerefreshList)
        {
            await _dbContext.Employeeattendancerefresh.AddRangeAsync(employeeattendancerefreshList);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
