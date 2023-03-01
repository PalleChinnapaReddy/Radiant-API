using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface ILineBusiness : IGenericBusiness<LineDto>
    {
        Task<List<LinesDashboardDto>> GetAllLines();
        Task<List<LineDto>> GetLineByDept(long deptId, long subdeptId);
        Task<List<DropdownValueDto>> GetLinesDDValues();
    }
}
