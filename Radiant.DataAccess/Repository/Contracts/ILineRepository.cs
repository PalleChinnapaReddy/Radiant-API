using Radiant.DataAccess.Models;
using Radiant.DataAccess.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface ILineRepository : IGenericRepository<Line>
    {
        Task<List<LinesDashboard>> GetLinesDashboards();
        Task<List<Line>> GetLineByDept(long deptId, long subdeptId);
        Task<List<DropdownValue>> GetLinesDDValues();
    }
}
