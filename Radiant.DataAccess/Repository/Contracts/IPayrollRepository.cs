using Radiant.DataAccess.Models;
using Radiant.DataAccess.Models.Reports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IPayrollRepository : IGenericRepository<Payroll>
    {
        Task<List<ConsolidationByMonth>> GetConsolidationByMonth(string contractorId);
        Task<AttendancePayrollResponse> GetPayrollAttendance(AttendancePayrollFilter attendancePayrollFilter);
        Task<ConsolidationAttendanceResponse> GetConsolidatedAttendanceByMonth(ConsolidatedAttendanceByMonthFilter filter);

        Task<PayrollResponse> GetReviewPayroll(PayrollFilter payrollFilter);
    }
}
