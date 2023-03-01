using Radiant.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IStageBusiness : IGenericBusiness<StageDto>
    {
        Task<List<StageDto>> GetStageByDeptAndLine(long deptId, long subdeptId, long lineId);

        Task<List<StageDto>> GetStageByLine(long lineId);

    }
}
