using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IHeadCountBusiness
    {
        Task<List<AssignedHeadCountDto>> GetAssignedHeadCounts(AssignedHeadCountRequestDto requestDto);
        Task UpdateAssignedHeadCounts(List<HeadCountAssignedTypeDto> headCountAssignedTypes);
    }
}
