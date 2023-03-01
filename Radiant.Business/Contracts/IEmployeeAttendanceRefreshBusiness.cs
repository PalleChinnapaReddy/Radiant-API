using Radiant.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IEmployeeAttendanceRefreshBusiness 
    {
        Task<bool> RefreshPostGreAttendance(List<EmployeeattendancerefreshDto> employeeattendancerefreshList);
    }
}
