using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class HeadCountRepository : IHeadCountRepository
    {
        private readonly ILogger<HeadCountRepository> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public HeadCountRepository(ILogger<HeadCountRepository> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<AssignedHeadCountModel>> GetAssignedHeadCounts(AssignedHeadCountRequestModel request)
        {
            var command = _dbContext.AssignedHeadCounts.FromSqlRaw($@"SELECT * from public.assignedheadcount('{request.DepartmentIds}','{request.ShiftId}'
                            , '{request.Date.ToString("yyyy-MM-dd")}')");

            return await command.ToListAsync();
        }

        public async Task UpdateAssignedHeadCounts(List<HeadCountAssignedType> headCountAssignedTypes)
        {
            foreach (var headCountAssignedType in headCountAssignedTypes)
            {
                var command = _dbContext.SqlWithStatusText.FromSqlRaw($@"SELECT * from public.upsertassignedheadcountbydldaily(
	{headCountAssignedType.DepartmentLineId},
    {headCountAssignedType.ShiftId},
	{headCountAssignedType.ContractorHeadCount},
	{headCountAssignedType.StaffHeadCount},
	'{headCountAssignedType.StartDate.ToString("yyyy-MM-dd")}',
	'{headCountAssignedType.EndDate.ToString("yyyy-MM-dd")}',
	{headCountAssignedType.IsActive})");

                await command.ToListAsync();
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
