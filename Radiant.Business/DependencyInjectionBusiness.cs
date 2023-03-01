using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Radiant.Business.Contracts;
using Radiant.Business.CoreBusiness;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.DataAccess;

namespace Radiant.Business
{
    public static class DependencyInjectionBusiness
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IGenericBusiness<AbsenceReasonDto>, AbsenceReasonBusiness>();
            services.AddScoped<IAttendanceOTApprovalBusiness, AttendanceOtApprovalBusiness>();
            services.AddScoped<ISearchableBusiness<ContractorDto, ContractorSearchDto>, ContractorBusiness>();
            services.AddScoped<IGenericBusiness<ContractorTrackerDto>, ContractorTrackerBusiness>();
            services.AddScoped<IGenericBusiness<CountryDto>, CountryBusiness>();
            services.AddScoped<ICityBusiness, CityBusiness>();
            services.AddScoped<IPayrollConfigBusiness, PayrollConfigBusiness>();
            services.AddScoped<IEmployeeAttendanceBusiness, EmployeeAttendanceBusiness>();
            services.AddScoped<IGenericBusiness<EmployeeAttendanceSummaryDto>, EmployeeAttendanceSummaryBusiness>();
            services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
            services.AddScoped<IGenericBusiness<EmployeeRoleTrackerDto>, EmployeeRoleTrackerBusiness>();
            services.AddScoped<IEmployeeTrackerBusiness, EmployeeTrackerBusiness>();
            services.AddScoped<ILineBusiness, LineBusiness>();
            services.AddScoped<IPayrollBusiness, PayrollBusiness>();
            services.AddScoped<IGenericBusiness<ProvinceDto>, ProvinceBusiness>();
            services.AddScoped<IGenericBusiness<RoleDto>, RoleBusiness>();
            services.AddScoped<IShiftBusiness, ShiftBusiness>();
            services.AddScoped<IGenericBusiness<SsntypeDto>, SsntypeBusiness>();
            services.AddScoped<IStageBusiness, StageBusiness>();
            services.AddScoped<IGenericBusiness<SupplyTypeDto>, SupplyTypeBusiness>();
            services.AddScoped<IGenericBusiness<PlantDto>, PlantBusiness>();
            services.AddScoped<IDepartmentBusiness, DepartmentBusiness>();
            services.AddScoped<IGenericBusiness<DesignationDto>,DesignationBusiness>();
            services.AddScoped<IGenericBusiness<EducationDto>, EducationBusiness>();
            services.AddScoped<IGenericBusiness<GenderDto>, GenderBusiness>();
            services.AddScoped<IGenericBusiness<AttendancetypeDto>, AttendanceTypeBusiness>();
            services.AddScoped<IGenericBusiness<OtStatusDto>, OtStatusBusiness>();
            services.AddScoped<IGenericBusiness<CurrencyDto>, CurrencyBusiness>();
            services.AddScoped<IEmployeeSkillBusiness, EmployeeSkillBusiness>();
            services.AddScoped<IPayrollDeductionBusiness, PayrollDeductionBusiness>();
            services.AddScoped<IScreensBusiness, ScreensBusiness>();


            services.AddScoped<IReportBusiness, ReportBusiness>();
            services.AddScoped<IRadiantHolidayBusiness, RadiantHolidayBusiness>();
            services.AddScoped<IEmployeeAttendanceRefreshBusiness, EmployeeAttendanceRefreshBusiness>();
            services.AddScoped<IMasterDataBusiness, MasterDataBusiness>();
            services.AddScoped<IHeadCountBusiness, HeadCountBusiness>();
            services.AddScoped<IPayrollShiftBusiness, PayrollShiftBusiness>();
            services.AddScoped<IGenericBusiness<HolidayTypeDto>, HolidayTypeBusiness>();



            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper());

            services.RegisterDataAccessLayer();
            return services;
        }
    }
}
