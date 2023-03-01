using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IEmployeeTrackerBusiness : IGenericBusiness<EmployeeTrackerDto>
    {
        Task<List<EmployeeTrackerDto>> CreateAll(EmployeeShiftUpdate employeeShiftUpdate);
    }
}
