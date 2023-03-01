using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IHeadCountRepository
    {
        Task<List<AssignedHeadCountModel>> GetAssignedHeadCounts(AssignedHeadCountRequestModel requestDto);
        Task UpdateAssignedHeadCounts(List<HeadCountAssignedType> headCountAssignedTypes);
    }
}
