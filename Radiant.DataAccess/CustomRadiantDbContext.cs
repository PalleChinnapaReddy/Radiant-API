using Microsoft.EntityFrameworkCore;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Models.Reports;

namespace Radiant.DataAccess
{
    public class CustomRadiantDbContext: RadiantDbContext
    {
        public virtual DbSet<AttendanceCountByDay> AttendanceCountByDay { get; set; }
        public virtual DbSet<AttendanceByEmployee> AttendanceByEmployee { get; set; }
        public virtual DbSet<AttendanceCountByShift> AttendanceCountByShift { get; set; }
        public virtual DbSet<HeadCountReportByDay> HeadCountReportByDay { get; set; }
        public virtual DbSet<AttendanceReportByDay> AttendanceReportByDay { get; set; }
        //public virtual DbSet<> MyProperty { get; set; }
        public virtual DbSet<EmpOTReport> EmpOTReport { get; set; }
        public virtual DbSet<EmpAttendanceRefresh> EmpAttendanceRefresh { get; set; }

        public virtual DbSet<EmpHierarchy> EmpHierarchy { get; set; }
        public virtual DbSet<LoadPayrollData> LoadPayrollData { get; set; }
        public virtual DbSet<DashboardLineMetrics> DashboardLineMetrics { get; set; }
        public virtual DbSet<DashboardMetrics> DashboardMetrics { get; set; }
        public virtual DbSet<DashboardShiftMetrics> DashboardShiftMetrics { get; set; }
        public virtual DbSet<OTRegister> OTRegister { get; set; }
        public virtual DbSet<VendorPayable> VendorPayable { get; set; }
        public virtual DbSet<WageSheetRegister> WageSheetRegister { get; set; }
        public virtual DbSet<UpsertEmpSalary> UpsertEmpSalary { get; set; }
        public virtual DbSet<ConsolidationByMonth> ConsolidationByMonth { get; set; }
        public virtual DbSet<ConsolidatedAttendancebyMonth> ConsolidationAttendanceByMonth { get; set; }
        public virtual DbSet<AttendancePayroll> AttendancePayroll { get; set; }
        
        public virtual DbSet<UpsertEmpSkill> UpsertEmpSkill { get; set; }
        public virtual DbSet<EmployeeSkillMatrix> EmployeeSkillMatrix { get; set; }
        public virtual DbSet<EmpSkill> EmpSkill { get; set; }
        public virtual DbSet<DepartmentWiseAttendanceReport> DepartmentWiseAttendanceReport { get; set; }
        public virtual DbSet<DayAttendanceReport> DayAttendanceReport { get; set; }
        public virtual DbSet<StatusModel> SqlWithStatusText { get; set; }
        public virtual DbSet<TotalRowsModel> SqlTotalRows { get; set; }

        public virtual DbSet<AssignedHeadCountModel> AssignedHeadCounts { get; set; }



        public CustomRadiantDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AttendanceCountByDay>(e =>
            {
                e.HasNoKey();
            });

            modelBuilder.Entity<AttendanceByEmployee>(e =>
            {
                e.HasNoKey();
            });

            modelBuilder.Entity<AttendanceCountByShift>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<AttendanceReportByDay>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<HeadCountReportByDay>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<EmpOTReport>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<EmpAttendanceRefresh>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<EmpHierarchy>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<OTRegister>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<DashboardShiftMetrics>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<DashboardMetrics>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<DashboardLineMetrics>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<VendorPayable>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<WageSheetRegister>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<LoadPayrollData>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<UpsertEmpSalary>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<ConsolidationByMonth>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<ConsolidatedAttendancebyMonth>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<UpsertEmpSkill>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<EmployeeSkillMatrix>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<EmpSkill>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<DepartmentWiseAttendanceReport>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<DayAttendanceReport>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<StatusModel>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<TotalRowsModel>(e =>
            {
                e.HasNoKey();
            });
            modelBuilder.Entity<AttendancePayroll>(e =>
            {
                e.HasNoKey();
            });

            modelBuilder.Entity<AssignedHeadCountModel>(e =>
            {
                e.HasNoKey();
            });
        }
    }
}
