using AutoMapper;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Reports;
using Radiant.Business.Models.Response;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Models.Reports;
using Radiant.DataAccess.Response;
using System;
using System.Linq;

namespace Radiant.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // DTO to Model Mapping - Business to Database
            CreateMap<AbsenceReasonDto, AbsenceReason>();
            CreateMap<AttendanceOtApprovalDto, AttendanceOtApproval>();
            CreateMap<ContractorDto, Contractor>();
            CreateMap<ContractorTrackerDto, ContractorTracker>();
            CreateMap<CountryDto, Country>();
            CreateMap<EmployeeAttendanceDto, EmployeeAttendance>();
            CreateMap<EmployeeAttendanceSummaryDto, EmployeeAttendanceSummary>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeDocumentsDto, Employeedocuments>();
            CreateMap<EmployeeRoleTrackerDto, EmployeeRoleTracker>();
            CreateMap<EmployeeTrackerDto, EmployeeTracker>();
            CreateMap<LineDto, Line>();
            CreateMap<PayrollDto, Payroll>();
            CreateMap<ProvinceDto, Province>();
            CreateMap<RoleDto, Role>();
            CreateMap<ShiftDto, Shift>();
            CreateMap<StageDto, Stage>();
            CreateMap<SupplyTypeDto, SupplyType>();
            CreateMap<GenderDto, Gender>();
            CreateMap<CurrencyDto, Currency>();
            CreateMap<SsntypeDto, Ssntype>();
            CreateMap<PlantDto, Plant>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<DesignationDto, Designation>();
            CreateMap<EducationDto, Education>();
            CreateMap<AttendanceByEmployeeDto, AttendanceByEmployee>();
            CreateMap<AttendanceByEmployeeFilterDto, AttendanceByEmployeeFilter>();
            CreateMap<AttendanceCountByDayDto, AttendanceCountByDay>();
            CreateMap<AttendanceCountByDayFilterDto, AttendanceCountByDayFilter>();
            CreateMap<AttendanceCountByShiftDto, AttendanceCountByShift>();
            CreateMap<AttendanceCountByShiftFilterDto, AttendanceCountByShiftFilter>();
            CreateMap<AttendancetypeDto, Attendancetype>();
            CreateMap<RadiantHolidayDto, RadiantHoliday>();
            CreateMap<ContractorSearchDto, ContractorSearch>();
            CreateMap<EmployeeattendancerefreshDto, Employeeattendancerefresh>();
            CreateMap<OtStatusDto, OtStatus>();
            CreateMap<HeadCountReportByDayDto, HeadCountReportByDay>();
            CreateMap<HeadCountReportByDayFilterDto, HeadCountReportByDayFilter>();
            CreateMap<AttendanceReportByDayDto, AttendanceReportByDay>();
            CreateMap<AttendanceReportByDayFilterDto, AttendanceReportByDayFilter>();
            CreateMap<MaritalstatusDto, Maritalstatus>();
            CreateMap<PaymenttypeDto, Paymenttype>();
            CreateMap<CityDto, City>();
            CreateMap<EmpOTReportDto, EmpOTReport>();
            CreateMap<EmpOTReportFilterDto, EmpOTReportFilter>();
            CreateMap<EmpAttendanceRefreshDto, EmpAttendanceRefresh>();
            CreateMap<EmpAttendanceRefreshRequestDto, EmpAttendanceRefreshRequest>();
            CreateMap<EmployeeSkillDto, Employeeskill>();
            CreateMap<ScreensDto, Screens>();
            CreateMap<LoadPayrollDataDto, LoadPayrollData>();
            CreateMap<DashboardMetricsDto, DashboardMetrics>();
            CreateMap<DashboardLineMetricsDto, DashboardLineMetrics>();
            CreateMap<DashboardShiftMetricsDto, DashboardShiftMetrics>();
            CreateMap<OTRegisterDto, OTRegister>();
            CreateMap<WageSheetRegisterDto, WageSheetRegister>();
            CreateMap<VendorPayableDto, VendorPayable>();
            CreateMap<ConsolidationByMonthDto, ConsolidationByMonth>();
            CreateMap<EmployeeSalaryDto, Employeesalary>();
            CreateMap<UpsertEmpSalaryDto, UpsertEmpSalary>();
            CreateMap<EmployeeSkillRequestDto, EmployeeSkillRequest>();
            CreateMap<EmployeeSkillMatrixDto, EmployeeSkillMatrix>();
            CreateMap<UpsertEmpSkillDto, UpsertEmpSkill>();
            CreateMap<EmpSkillDto, EmpSkill>();
            CreateMap<EmployeeSearchDto, EmployeeSearch>();
            CreateMap<DropdownValueDto, DropdownValue>();
            CreateMap<EmployeeAttendanceSearchDto, EmployeeAttendanceSearch>();
            CreateMap<RadiantHolidayFilterDto, RadiantHolidayFilter>();




            CreateMap<AttendanceOtSearchDto, AttendanceOtSearch>().ReverseMap();
            CreateMap<Payrolldeduction, PayrolldeductionDto>().ReverseMap();
            CreateMap<AttendanceOTApprovalResponseDto, AttendanceOTApprovalResponse>().ReverseMap();
            CreateMap<EmployeeSkillSearchDto, EmployeeSkillSearch>().ReverseMap();
            CreateMap<EmployeeLinesDashboardResponseDto, EmployeeLinesDashboardResponse>().ReverseMap();
            CreateMap<EmployeeLinesDashboardSearchDto, EmployeeLinesDashboardSearch>().ReverseMap();
            CreateMap<EmployeeLinesDashboardDto, EmployeeLinesDashboard>().ReverseMap();
            CreateMap<PayrollConfigDto, Payrollconfig>().ReverseMap();
            CreateMap<Attachments, AttachmentsDto>().ReverseMap();
            CreateMap<EmployeeBulkEditModel, EmployeeBulkEditDto>().ReverseMap();
            CreateMap<DepartmentWiseAttendanceReport, DepartmentWiseAttendanceReportDto>().ReverseMap();
            CreateMap<DayAttendanceReport, DayAttendanceReportDto>().ReverseMap();
            CreateMap<UpdateDependencyModel, UpdateDependencyDto>().ReverseMap();
            CreateMap<Contractordocuments, ContractordocumentsDto>().ReverseMap();
            CreateMap<DepartmentlinemappingDto, Departmentlinemapping>().ReverseMap();
            CreateMap<EmployeeDeleteDto, EmployeeDeleteModel>().ReverseMap();
            CreateMap<EmployeeBulkDeleteDto, EmployeeBulkDeleteModel>().ReverseMap();
            CreateMap<AssignedHeadCountDto, AssignedHeadCountModel>().ReverseMap();
            CreateMap<AssignedHeadCountRequestDto, AssignedHeadCountRequestModel>().ReverseMap();
            CreateMap<HeadCountAssignedType, HeadCountAssignedTypeDto>().ReverseMap();
            CreateMap<Holidaytype, HolidayTypeDto>().ReverseMap();
            CreateMap<AttendancePayroll, AttendancePayrollDto>().ReverseMap();
            CreateMap<AttendancePayrollFilter, AttendancePayrollFilterDto>().ReverseMap();
            CreateMap<PayrollshiftDto, Payrollshift>().ReverseMap();


            //Model to DTO Mapping  - Database to Business
            CreateMap<AbsenceReason, AbsenceReasonDto>();
            CreateMap<AttendanceOtApproval, AttendanceOtApprovalDto>();
            CreateMap<Contractor, ContractorDto>();
            CreateMap<ContractorTracker, ContractorTrackerDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<EmployeeAttendance, EmployeeAttendanceDto>()
                .ForMember(a=>a.DepartmentId, m=>m.MapFrom(ea=>ea.Emp.CurrentDepartmentid))
                .ForMember(a => a.SubDepartmentId, m => m.MapFrom(ea => ea.Emp.Subdepartmentid))
                .ForMember(a => a.ContractorId, m => m.MapFrom(ea => ea.Emp.CurrentContractorid))
                .ForMember(a => a.Department, m => m.MapFrom(ea => ea.Emp.CurrentDepartment.Departmentdescription))
                .ForMember(a => a.SubDepartment, m => m.MapFrom(ea => ea.Emp.Subdepartment.Departmentdescription))
                .ForMember(a => a.Contractor, m => m.MapFrom(ea => ea.Emp.CurrentContractor.Name));
            CreateMap<EmployeeAttendanceSummary, EmployeeAttendanceSummaryDto>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(l => l.Employeedocuments, m => m.MapFrom(ds => ds.Employeedocuments.Where(d => d.Isactive == true).ToList()));
            CreateMap<Employeedocuments, EmployeeDocumentsDto>();
            CreateMap<EmployeeRoleTracker, EmployeeRoleTrackerDto>();
            CreateMap<EmployeeTracker, EmployeeTrackerDto>();
            CreateMap<Line, LineDto>()
                .ForMember(l => l.ActiveEmployeeCount, m => m.MapFrom(ds => ds.Employee.Where(e => e.Isactive == true).Count()))
                .ForMember(l => l.Stage, m => m.MapFrom(ds => ds.Stage.Where(e => e.Isactive == true)));
            CreateMap<LinesDashboard, LinesDashboardDto>();
            CreateMap<Payroll, PayrollDto>();
            CreateMap<Province, ProvinceDto>();
            CreateMap<Role, RoleDto>();
            //.ForMember(r => r.ActiveEmployeeCount, m => m.MapFrom(ds => ds.Employee.Where(e => e.Isactive == true).Count()))
            //.ForMember(r => r.TotalEmployeeCount, m => m.MapFrom(ds => ds.Employee.Count))

            CreateMap<Shift, ShiftDto>()
                .ForMember(s => s.EmployeeCount, m => m.MapFrom(ds => ds.Employee.Where(e => e.Isactive == true).Count()));
            CreateMap<Stage, StageDto>()
                .ForMember(s => s.ActiveEmployeeCount, m => m.MapFrom(ds => ds.Employee.Where(e => e.Isactive == true).Count()))
                .ForMember(s => s.PresentEmployeeCount, m => m.MapFrom(ds => ds.EmployeeAttendance.Where(
                         e => e.Attendancedate == DateTime.Now.Date
                         && (e.AttendanceType.Description.Trim().ToString() == "Biometric Data"
                         || 
                         (e.AttendanceType.Description.Trim().ToString() == "Manual Request"
                         && e.AttendanceOtApproval.Any(o => o.Otstatusid != null && o.Otstatus.Otstatusdescription.Trim().ToString() == "Approved"))
                         )
                         )
                     .Count()));
            CreateMap<SupplyType, SupplyTypeDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<Ssntype, SsntypeDto>();
            CreateMap<Plant, PlantDto>();
            CreateMap<Department, DepartmentDto>()
                .ForMember(s => s.EmployeeCount, m => m.MapFrom(ds => ds.EmployeeCurrentDepartment.Where(ecd => ecd.Isactive == true).Count()
                + ds.EmployeeSubdepartment.Where(ecd => ecd.Isactive == true).Count()));
            CreateMap<Designation, DesignationDto>();
            CreateMap<Education, EducationDto>();
            CreateMap<AttendanceByEmployee, AttendanceByEmployeeDto>();
            CreateMap<AttendanceByEmployeeFilter, AttendanceByEmployeeFilterDto>();
            CreateMap<AttendanceCountByDay, AttendanceCountByDayDto>();
            CreateMap<AttendanceCountByDayFilter, AttendanceCountByDayFilterDto>();
            CreateMap<AttendanceCountByShift, AttendanceCountByShiftDto>();
            CreateMap<AttendanceCountByShiftFilter, AttendanceCountByShiftFilterDto>();
            CreateMap<Attendancetype, AttendancetypeDto>();
            CreateMap<Employeeattendancerefresh, EmployeeattendancerefreshDto>();
            CreateMap<RadiantHoliday, RadiantHolidayDto>();
            CreateMap<OtStatus, OtStatusDto>();
            CreateMap<HeadCountReportByDay, HeadCountReportByDayDto>();
            CreateMap<HeadCountReportByDayFilter, HeadCountReportByDayFilterDto>();
            CreateMap<AttendanceReportByDay, AttendanceReportByDayDto>();
            CreateMap<AttendanceReportByDayFilter, AttendanceReportByDayFilterDto>();
            CreateMap<Maritalstatus, MaritalstatusDto>();
            CreateMap<Paymenttype, PaymenttypeDto>();
            CreateMap<City, CityDto>();
            CreateMap<EmpOTReport, EmpOTReportDto>();
            CreateMap<EmpOTReportFilter, EmpOTReportFilterDto>();
            CreateMap<EmpAttendanceRefresh, EmpAttendanceRefreshDto>();
            CreateMap<EmpAttendanceRefreshRequest, EmpAttendanceRefreshRequestDto>();
            CreateMap<Employeeskill, EmployeeSkillDto>();
            CreateMap<Employeesalary, EmployeeSalaryDto>();
            CreateMap<Screens, ScreensDto>();
            CreateMap<LoadPayrollData, LoadPayrollDataDto>();
            CreateMap<EmpHierarchy, EmpHierarchyDto>();
            CreateMap<DashboardMetrics, DashboardMetricsDto>();
            CreateMap<DashboardLineMetrics, DashboardLineMetricsDto>();
            CreateMap<DashboardShiftMetrics, DashboardShiftMetricsDto>();
            CreateMap<OTRegister, OTRegisterDto>();
            CreateMap<WageSheetRegister, WageSheetRegisterDto>();
            CreateMap<VendorPayable, VendorPayableDto>();
            CreateMap<ConsolidationByMonth, ConsolidationByMonthDto>();
            CreateMap<UpsertEmpSalary, UpsertEmpSalaryDto>();
            CreateMap<UpsertEmpSkill, UpsertEmpSkillDto>();
            CreateMap<EmployeeSkillRequest, EmployeeSkillRequestDto>();
            CreateMap<EmployeeSkillMatrix, EmployeeSkillMatrixDto>();
            CreateMap<EmpSkill, EmpSkillDto>();
            CreateMap<DropdownValue, DropdownValueDto>();
            CreateMap<EmployeeSearchResponse, EmployeeSearchResponseDto>();
            CreateMap<EmployeeAttendanceResponse, EmployeeAttendanceResponseDto>();
            CreateMap<BulkReactivateModel, BulkReactivateDto>().ReverseMap();
            CreateMap<EmployeeDropdownModel, EmployeeDropdownDto>().ReverseMap();
            CreateMap<SelectedEmployeeDetails, SelectedEmployeeDetailsDto>().ReverseMap();
            CreateMap<EmployeeSkillSummaryModel, EmployeeSkillSummaryDto>().ReverseMap();
            CreateMap<RatingModel, RatingDto>().ReverseMap();
            CreateMap<Holidaytype, HolidayTypeDto>().ReverseMap();
            CreateMap<AttendancePayrollResponse, AttendancePayrollResponseDto>().ReverseMap();
            CreateMap<TotalRowsModel, TotalRowsModelDto>().ReverseMap();
            CreateMap<ConsolidatedAttendanceByMonthFilter, ConsolidatedAttendanceByMonthFilterDto>().ReverseMap();
            CreateMap<ConsolidatedAttendancebyMonth, ConsolidatedAttendancebyMonthDto>().ReverseMap();
            CreateMap<ConsolidationAttendanceResponse, ConsolidationAttendanceResponseDto>().ReverseMap();
            CreateMap<RadiantHolidayFilter, RadiantHolidayFilterDto>().ReverseMap();
            CreateMap<PayrollResponse, PayrollResponseDto>().ReverseMap();
            CreateMap<PayrollFilter, PayrollFilterDto>().ReverseMap();

        }
    }
}
