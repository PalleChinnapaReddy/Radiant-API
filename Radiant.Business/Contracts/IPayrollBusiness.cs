using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IPayrollBusiness:IGenericBusiness<PayrollDto>
    {
        Task<List<ConsolidationByMonthDto>> GetConsolidationByMonth(string contractor);
        Task<AttendancePayrollResponseDto> GetPayrollAttendance(AttendancePayrollFilterDto attendancePayrollFilter);

        Task<ConsolidationAttendanceResponseDto> GetConsolidatedAttendanceByMonth(ConsolidatedAttendanceByMonthFilterDto filter);
        Task<PayrollResponseDto> GetReviewPayroll(PayrollFilterDto payrollFilter);

    }
}
