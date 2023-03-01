using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository;
using Radiant.DataAccess.Repository.Contracts;

namespace Radiant.DataAccess
{
    public static class DependencyInjectionDataAccess
    {
        public static IServiceCollection RegisterDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<AbsenceReason>, AbsenceReasonRepository>();
            services.AddScoped<IAttendanceOTApprovalRepository, AttendanceOtApprovalRepository>();
            services.AddScoped<ISearchableRepository<Contractor, ContractorSearch>, ContractorRepository>();
            services.AddScoped<IGenericRepository<ContractorTracker>, ContractorTrackerRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPayrollConfigRepository, PayrollConfigRepository>();
            services.AddScoped<IGenericRepository<Country>, CountryRepository>();
            services.AddScoped<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();
            services.AddScoped<IGenericRepository<EmployeeAttendanceSummary>, EmployeeAttendanceSummaryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTrackerRepository, EmployeeTrackerRepository>();
            services.AddScoped<IGenericRepository<EmployeeRoleTracker>, EmployeeRoleTrackerRepository>();
            services.AddScoped<IGenericRepository<EmployeeTracker>, EmployeeTrackerRepository>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<IGenericRepository<Province>, ProvinceRepository>();
            services.AddScoped<IGenericRepository<Role>, RoleRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IGenericRepository<Ssntype>, SsntypeRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IGenericRepository<SupplyType>, SupplyTypeRepository>();
            services.AddScoped<IGenericRepository<Currency>, CurrencyRepository>();
            services.AddScoped<IGenericRepository<Gender>, GenderRepository>();
            services.AddScoped<IGenericRepository<Plant>, PlantRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IGenericRepository<Designation>, DesignationRepository>();
            services.AddScoped<IGenericRepository<Education>, EducationRepository>();
            services.AddScoped<IGenericRepository<Attendancetype>, AttendanceTypeRepository>();
            services.AddScoped<IGenericRepository<OtStatus>, OtStatusRepository>();
            services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();
            services.AddScoped<IScreensRepository, ScreensRepository>();
            services.AddScoped<IEmployeeAttendanceRefreshRepository, EmployeeAttendanceRefreshRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IRadiantHolidayRepository, RadiantHolidayRepository>();
            services.AddScoped<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<IHeadCountRepository, HeadCountRepository>();
            services.AddScoped<IPayrollShiftRepository, PayrollShiftRepository>();
            services.AddScoped<IGenericRepository<Holidaytype>, HolidayTypeRepository>();
            services.AddScoped<IPayrollDeductionRepository, PayrollDeductionRepository>();

            services.AddDbContext<CustomRadiantDbContext>(options =>
            options.UseNpgsql(DataAccessHelper.GetConnectionString())
            );
            return services;
        }
    }
}
