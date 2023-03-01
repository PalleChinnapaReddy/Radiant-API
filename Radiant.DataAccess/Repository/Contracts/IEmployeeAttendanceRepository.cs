using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IEmployeeAttendanceRepository : IGenericRepository<EmployeeAttendance>
    {
        Task<EmployeeAttendanceResponse> GetEmployeeAttendanceByManager(EmployeeAttendanceSearch filterModel);
        Task<List<DayAttendanceReport>> GetAttendanceReports(string shift, DateTime date);
        Task<SelectedEmployeeDetails> GetSelectedEmployeeDetails(int id);
    }
}
