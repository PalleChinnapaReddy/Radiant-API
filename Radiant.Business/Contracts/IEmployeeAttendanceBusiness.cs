using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IEmployeeAttendanceBusiness : IGenericBusiness<EmployeeAttendanceDto>
    {
        Task Create(List<EmployeeDto> item);

        Task<EmployeeAttendanceResponseDto> GetEmployeeAttendanceByManager(EmployeeAttendanceSearchDto searchDto);
        Task<List<DayAttendanceReportDto>> GetAttendanceReports(string shift, DateTime date);
        Task<SelectedEmployeeDetailsDto> GetSelectedEmployeeDetails(int id);
    }
}
