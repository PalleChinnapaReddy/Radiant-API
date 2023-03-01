using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IStageRepository : IGenericRepository<Stage>
    {
        Task<List<Stage>> GetStageByDeptAndLine(long deptId, long subdeptId, long lineId);
        Task<List<Stage>> GetStageLine(long lineId);
    }
}
