using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IEmployeeAttendanceRefreshRepository 
    {
        Task<bool> RefreshPostGreAttendance(List<Employeeattendancerefresh> employeeattendancerefreshList);
    }
}
