using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Models.Reports;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ILogger<Payroll> _logger;
        private readonly CustomRadiantDbContext _dbContext;
        public PayrollRepository(ILogger<Payroll> logger
            , CustomRadiantDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Payroll> Create(Payroll record)
        {
            await _dbContext.Payroll.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var payroll = await GetById(id);
            payroll.Isactive = false;
            _dbContext.Payroll.Update(payroll);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Payroll> Edit(Payroll record)
        {
            _dbContext.Payroll.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Payroll>> GetAll()
        {
            return await _dbContext.Payroll
                .Where(p => p.Isactive == true)
                .OrderByDescending(p => p.CreatedOn)
                .AsNoTracking().ToListAsync();

        }

        public async Task<Payroll> GetById(long id)
        {
            return await _dbContext.Payroll
                .FirstOrDefaultAsync(x => x.Payrollid == id);
        }

        public Task<Payroll> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ConsolidationByMonth>> GetConsolidationByMonth(string contractorId)
        {
            var command = _dbContext.ConsolidationByMonth.FromSqlRaw($@"
            SELECT * from public.Consolidation_ByMonth(
            '{contractorId}'--contractorId
            )");
            return await command.ToListAsync();
        }

        public async Task<AttendancePayrollResponse> GetPayrollAttendance(AttendancePayrollFilter attendancePayrollFilter)
        {
            //var empcodeFilter = attendancePayrollFilter.EmpCode.HasValue ? $"employeecode = {attendancePayrollFilter.EmpCode}" : "1=1";
            var totalRecords = attendancePayrollFilter.PageSize != int.MaxValue ? _dbContext.SqlTotalRows.FromSqlRaw($@"
            select count(1) as total_records from payrollattendancebymonth(
            '{attendancePayrollFilter.Contractor}',--contractor
            '{attendancePayrollFilter.StageId}',--lineid
            '{attendancePayrollFilter.ShiftId}',--stageid
            '{attendancePayrollFilter.LineId}',
            '{attendancePayrollFilter.InActivePresent}',
            '{attendancePayrollFilter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{attendancePayrollFilter.EndDate.ToString("yyyy-MM-dd")}',
            '{attendancePayrollFilter.EmpCode}'
            ) --enddate
            ").FirstOrDefault() :
            _dbContext.SqlTotalRows.FromSqlRaw($@"
            select count(1) as total_records
            ").FirstOrDefault();
            var command = attendancePayrollFilter.PageSize != int.MaxValue ? _dbContext.AttendancePayroll.FromSqlRaw($@"
            select * from (
            select row_number() OVER (order by employeecode,punchdate) as rnum,* from payrollattendancebymonth(
            '{attendancePayrollFilter.Contractor}',--contractor
            '{attendancePayrollFilter.StageId}',--lineid
            '{attendancePayrollFilter.ShiftId}',--stageid
            '{attendancePayrollFilter.LineId}',
            '{attendancePayrollFilter.InActivePresent}',
            '{attendancePayrollFilter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{attendancePayrollFilter.EndDate.ToString("yyyy-MM-dd")}', --enddate
            '{attendancePayrollFilter.EmpCode}'
            ) 
            order by employeecode,punchdate ) as result
            where 
            rnum between '{(attendancePayrollFilter.PageNumber * attendancePayrollFilter.PageSize) + 1}' 
            and '{(attendancePayrollFilter.PageNumber + 1) * attendancePayrollFilter.PageSize}'") :
            _dbContext.AttendancePayroll.FromSqlRaw($@"
            select row_number() OVER (order by employeecode,punchdate) as rnum,* from payrollattendancebymonth(
            '{attendancePayrollFilter.Contractor}',--contractor
            '{attendancePayrollFilter.StageId}',--lineid
            '{attendancePayrollFilter.ShiftId}',--stageid
            '{attendancePayrollFilter.LineId}',
            '{attendancePayrollFilter.InActivePresent}',
            '{attendancePayrollFilter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{attendancePayrollFilter.EndDate.ToString("yyyy-MM-dd")}', --enddate
            '{attendancePayrollFilter.EmpCode}'
            ) 
            order by employeecode,punchdate");
            return new AttendancePayrollResponse
            {
                TotalRows = totalRecords.total_records,
                Data = await command.ToListAsync()

                //Data = await command.Where(r => !attendancePayrollFilter.EmpCode.HasValue || r.EmployeeId == attendancePayrollFilter.EmpCode).ToListAsync()
            };
        }

        public async Task<ConsolidationAttendanceResponse> GetConsolidatedAttendanceByMonth(ConsolidatedAttendanceByMonthFilter filter)
        {
            var empcodeFilter = filter.EmpCode.HasValue ? $"empCode = {filter.EmpCode}" : "1=1";
            var countQuery = filter.PageSize != null ? $@" SELECT count(1) as total_records from public.consolidatedattendancebymonth(
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            )    
            where {empcodeFilter}" : $@" SELECT count(1) as total_records";
            var query = filter.PageSize != null ? $@"
            select * from( SELECT row_number() OVER (order by empid) as rnum,* from public.consolidatedattendancebymonth(
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            ) 
            where {empcodeFilter}
            order by empcode) as result
            where rnum between '{(filter.PageNumber * filter.PageSize) + 1}' and '{(filter.PageNumber + 1) * filter.PageSize}'" :
             $@"
            SELECT * from public.consolidatedattendancebymonth(
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            ) order by empid";
            var countCommand = _dbContext.SqlTotalRows.FromSqlRaw(countQuery);
            var command = _dbContext.ConsolidationAttendanceByMonth.FromSqlRaw(query);
            return new ConsolidationAttendanceResponse
            {
                //Data = await command.Where(r => !filter.EmpCode.HasValue || r.EmpCode == filter.EmpCode).ToListAsync(),
                Data = await command.ToListAsync(),
                TotalRows = countCommand.FirstOrDefault().total_records
            };
        }

        public async Task<PayrollResponse> GetReviewPayroll(PayrollFilter payrollFilter)
        {
            var payrollResponse = new PayrollResponse();
            var query = _dbContext.Payroll.Where((p) =>
                 (!payrollFilter.PayrollDate.HasValue ||

                 (payrollFilter.PayrollDate.Value.Month == p.Month 
                 && payrollFilter.PayrollDate.Value.Year == p.Year)) &&

                 (!payrollFilter.DepartmentId.HasValue || p.Emp.CurrentDepartmentid == payrollFilter.DepartmentId) &&
                 (!payrollFilter.ContractorId.HasValue || p.Emp.CurrentContractorid == payrollFilter.ContractorId) &&
                 (!payrollFilter.LineId.HasValue || p.Emp.CurrentLineid == payrollFilter.LineId) &&
                 (!payrollFilter.ManagerId.HasValue || p.Emp.CurrentLinemanagerid == payrollFilter.ManagerId) &&
                 (!payrollFilter.ShiftId.HasValue || p.Emp.CurrentShiftid == payrollFilter.ShiftId)
            );
            payrollResponse.TotalRows = query.Count();
            payrollResponse.Payrolls = await query.OrderBy(c => c.Emp.Empcode)
                .Skip((payrollFilter.PageNumber) * payrollFilter.PageSize)
                .Take(payrollFilter.PageSize)
                .AsNoTracking().ToListAsync();
            return payrollResponse;

        }
    }
}