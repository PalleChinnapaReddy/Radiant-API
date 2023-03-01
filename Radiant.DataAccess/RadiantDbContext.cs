using Microsoft.EntityFrameworkCore;
using Radiant.DataAccess.Models;

namespace Radiant.DataAccess
{
    public partial class RadiantDbContext : DbContext
    {
        public RadiantDbContext()
        {
        }

        public RadiantDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceReason> AbsenceReason { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<AttendanceOtApproval> AttendanceOtApproval { get; set; }
        public virtual DbSet<Attendancetype> Attendancetype { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<ContractorTracker> ContractorTracker { get; set; }
        public virtual DbSet<Contractordocuments> Contractordocuments { get; set; }
        public virtual DbSet<Contractorload> Contractorload { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Departmentlineheadcount> Departmentlineheadcount { get; set; }
        public virtual DbSet<DepartmentlineheadcountArchive> DepartmentlineheadcountArchive { get; set; }
        public virtual DbSet<Departmentlinemapping> Departmentlinemapping { get; set; }
        public virtual DbSet<DepartmentlinemappingArchive> DepartmentlinemappingArchive { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual DbSet<EmployeeAttendanceHist> EmployeeAttendanceHist { get; set; }
        public virtual DbSet<EmployeeAttendanceSummary> EmployeeAttendanceSummary { get; set; }
        public virtual DbSet<EmployeeRoleTracker> EmployeeRoleTracker { get; set; }
        public virtual DbSet<EmployeeRoleTrackerArchive> EmployeeRoleTrackerArchive { get; set; }
        public virtual DbSet<EmployeeTracker> EmployeeTracker { get; set; }
        public virtual DbSet<EmployeeTrackerArchive> EmployeeTrackerArchive { get; set; }
        public virtual DbSet<Employeeattendancerefresh> Employeeattendancerefresh { get; set; }
        public virtual DbSet<Employeedocuments> Employeedocuments { get; set; }
        public virtual DbSet<Employeesalary> Employeesalary { get; set; }
        public virtual DbSet<Employeeskill> Employeeskill { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Holidaytype> Holidaytype { get; set; }
        public virtual DbSet<Lefthrms> Lefthrms { get; set; }
        public virtual DbSet<Line> Line { get; set; }
        public virtual DbSet<Loaddata> Loaddata { get; set; }
        public virtual DbSet<Loaddatafa> Loaddatafa { get; set; }
        public virtual DbSet<Loaddatalcm> Loaddatalcm { get; set; }
        public virtual DbSet<Loadempdata> Loadempdata { get; set; }
        public virtual DbSet<Loadtest> Loadtest { get; set; }
        public virtual DbSet<Loadtest1> Loadtest1 { get; set; }
        public virtual DbSet<Loadtest2> Loadtest2 { get; set; }
        public virtual DbSet<Loadtest3> Loadtest3 { get; set; }
        public virtual DbSet<Maritalstatus> Maritalstatus { get; set; }
        public virtual DbSet<OtStatus> OtStatus { get; set; }
        public virtual DbSet<Paymenttype> Paymenttype { get; set; }
        public virtual DbSet<Payroll> Payroll { get; set; }
        public virtual DbSet<Payrollconfig> Payrollconfig { get; set; }
        public virtual DbSet<Payrolldeduction> Payrolldeduction { get; set; }
        public virtual DbSet<Payrollshift> Payrollshift { get; set; }
        public virtual DbSet<Payrollstatus> Payrollstatus { get; set; }
        public virtual DbSet<Plant> Plant { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<RadiantHoliday> RadiantHoliday { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Screens> Screens { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Ssntype> Ssntype { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<SupplyType> SupplyType { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(DataAccessHelper.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<AbsenceReason>(entity =>
            {
                entity.ToTable("absence_reason");

                entity.Property(e => e.Absencereasonid)
                    .HasColumnName("absencereasonid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Absencereasondetails)
                    .IsRequired()
                    .HasColumnName("absencereasondetails")
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.ToTable("attachments");

                entity.Property(e => e.Attachmentsid)
                    .HasColumnName("attachmentsid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Attachmentfor)
                    .HasColumnName("attachmentfor")
                    .HasColumnType("character varying");

                entity.Property(e => e.Attachmentsdetails)
                    .IsRequired()
                    .HasColumnName("attachmentsdetails")
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<AttendanceOtApproval>(entity =>
            {
                entity.HasKey(e => e.Attendanceapprovalid)
                    .HasName("attendanceapprovalid_pkey");

                entity.ToTable("attendance_ot_approval");

                entity.Property(e => e.Attendanceapprovalid)
                    .HasColumnName("attendanceapprovalid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Approvedempid).HasColumnName("approvedempid");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("character varying");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Employeeattendanceid).HasColumnName("employeeattendanceid");

                entity.Property(e => e.Otstatusid).HasColumnName("otstatusid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Employeeattendance)
                    .WithMany(p => p.AttendanceOtApproval)
                    .HasForeignKey(d => d.Employeeattendanceid)
                    .HasConstraintName("fk_att_emp_approve");

                entity.HasOne(d => d.Otstatus)
                    .WithMany(p => p.AttendanceOtApproval)
                    .HasForeignKey(d => d.Otstatusid)
                    .HasConstraintName("fk_attendance_ot_approval");
            });

            modelBuilder.Entity<Attendancetype>(entity =>
            {
                entity.ToTable("attendancetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => e.DateDimId)
                    .HasName("d_date_date_dim_id_pk");

                entity.ToTable("calendar");

                entity.HasIndex(e => e.DateActual)
                    .HasName("d_date_date_actual_idx");

                entity.Property(e => e.DateDimId)
                    .HasColumnName("date_dim_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateActual)
                    .HasColumnName("date_actual")
                    .HasColumnType("date");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasColumnName("day_name")
                    .HasMaxLength(9);

                entity.Property(e => e.DayOfMonth).HasColumnName("day_of_month");

                entity.Property(e => e.DayOfQuarter).HasColumnName("day_of_quarter");

                entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");

                entity.Property(e => e.DayOfYear).HasColumnName("day_of_year");

                entity.Property(e => e.DaySuffix)
                    .IsRequired()
                    .HasColumnName("day_suffix")
                    .HasMaxLength(4);

                entity.Property(e => e.Epoch).HasColumnName("epoch");

                entity.Property(e => e.FirstDayOfMonth)
                    .HasColumnName("first_day_of_month")
                    .HasColumnType("date");

                entity.Property(e => e.FirstDayOfQuarter)
                    .HasColumnName("first_day_of_quarter")
                    .HasColumnType("date");

                entity.Property(e => e.FirstDayOfWeek)
                    .HasColumnName("first_day_of_week")
                    .HasColumnType("date");

                entity.Property(e => e.FirstDayOfYear)
                    .HasColumnName("first_day_of_year")
                    .HasColumnType("date");

                entity.Property(e => e.LastDayOfMonth)
                    .HasColumnName("last_day_of_month")
                    .HasColumnType("date");

                entity.Property(e => e.LastDayOfQuarter)
                    .HasColumnName("last_day_of_quarter")
                    .HasColumnType("date");

                entity.Property(e => e.LastDayOfWeek)
                    .HasColumnName("last_day_of_week")
                    .HasColumnType("date");

                entity.Property(e => e.LastDayOfYear)
                    .HasColumnName("last_day_of_year")
                    .HasColumnType("date");

                entity.Property(e => e.Mmddyyyy)
                    .IsRequired()
                    .HasColumnName("mmddyyyy")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Mmyyyy)
                    .IsRequired()
                    .HasColumnName("mmyyyy")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.MonthActual).HasColumnName("month_actual");

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasColumnName("month_name")
                    .HasMaxLength(9);

                entity.Property(e => e.MonthNameAbbreviated)
                    .IsRequired()
                    .HasColumnName("month_name_abbreviated")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.QuarterActual).HasColumnName("quarter_actual");

                entity.Property(e => e.QuarterName)
                    .IsRequired()
                    .HasColumnName("quarter_name")
                    .HasMaxLength(9);

                entity.Property(e => e.WeekOfMonth).HasColumnName("week_of_month");

                entity.Property(e => e.WeekOfYear).HasColumnName("week_of_year");

                entity.Property(e => e.WeekOfYearIso)
                    .IsRequired()
                    .HasColumnName("week_of_year_iso")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.WeekendIndr).HasColumnName("weekend_indr");

                entity.Property(e => e.YearActual).HasColumnName("year_actual");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Cityid)
                    .HasColumnName("cityid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.City1)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Provinceid).HasColumnName("provinceid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.Provinceid)
                    .HasConstraintName("fk_city_prov");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Companyid)
                    .HasColumnName("companyid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(50);

                entity.Property(e => e.Company1)
                    .HasColumnName("company")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("contractor");

                entity.Property(e => e.Contractorid)
                    .HasColumnName("contractorid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Accountnumber)
                    .HasColumnName("accountnumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("address1")
                    .HasMaxLength(500);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(250);

                entity.Property(e => e.Agreementperiod)
                    .HasColumnName("agreementperiod")
                    .HasMaxLength(250);

                entity.Property(e => e.Bankname)
                    .HasColumnName("bankname")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrentLinemanagerid).HasColumnName("current_linemanagerid");

                entity.Property(e => e.CurrentStagemanagerid).HasColumnName("current_stagemanagerid");

                entity.Property(e => e.Esic)
                    .HasColumnName("esic")
                    .HasMaxLength(50);

                entity.Property(e => e.Gst)
                    .IsRequired()
                    .HasColumnName("gst")
                    .HasMaxLength(50);

                entity.Property(e => e.Ifsc)
                    .HasColumnName("ifsc")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Laborlicencenumber)
                    .HasColumnName("laborlicencenumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Ownername)
                    .HasColumnName("ownername")
                    .HasMaxLength(250);

                entity.Property(e => e.Ownerphonenumber)
                    .HasColumnName("ownerphonenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Pan)
                    .HasColumnName("pan")
                    .HasMaxLength(50);

                entity.Property(e => e.Peliancesno)
                    .HasColumnName("peliancesno")
                    .HasMaxLength(50);

                entity.Property(e => e.Pfregistrationnumber)
                    .HasColumnName("pfregistrationnumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Superviorname)
                    .IsRequired()
                    .HasColumnName("superviorname")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Vendorname)
                    .HasColumnName("vendorname")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ContractorTracker>(entity =>
            {
                entity.HasKey(e => e.Contactortrackerid)
                    .HasName("contactortrackerid_pkey");

                entity.ToTable("contractor_tracker");

                entity.Property(e => e.Contactortrackerid)
                    .HasColumnName("contactortrackerid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Contractorid).HasColumnName("contractorid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Supplytypeid).HasColumnName("supplytypeid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.ContractorTracker)
                    .HasForeignKey(d => d.Contractorid)
                    .HasConstraintName("fk_con");

                entity.HasOne(d => d.Supplytype)
                    .WithMany(p => p.ContractorTracker)
                    .HasForeignKey(d => d.Supplytypeid)
                    .HasConstraintName("fk_supplytypeid");
            });

            modelBuilder.Entity<Contractordocuments>(entity =>
            {
                entity.ToTable("contractordocuments");

                entity.Property(e => e.Contractordocumentsid)
                    .HasColumnName("contractordocumentsid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Attachmentid).HasColumnName("attachmentid");

                entity.Property(e => e.Contractordocuments1)
                    .IsRequired()
                    .HasColumnName("contractordocuments")
                    .HasColumnType("character varying(500)[]");

                entity.Property(e => e.Contractorid).HasColumnName("contractorid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.Contractordocuments)
                    .HasForeignKey(d => d.Attachmentid)
                    .HasConstraintName("fk_employee_attachements");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Contractordocuments)
                    .HasForeignKey(d => d.Contractorid)
                    .HasConstraintName("fk_contactor_emplyeedocuments");
            });

            modelBuilder.Entity<Contractorload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contractorload");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250);

                entity.Property(e => e.Agreementperiod)
                    .HasColumnName("agreementperiod")
                    .HasMaxLength(250);

                entity.Property(e => e.Bankaccountdetails)
                    .HasColumnName("bankaccountdetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Esic)
                    .HasColumnName("esic")
                    .HasMaxLength(250);

                entity.Property(e => e.Gstno)
                    .HasColumnName("gstno")
                    .HasMaxLength(250);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("ifsccode")
                    .HasMaxLength(250);

                entity.Property(e => e.Labourlicenceno)
                    .HasColumnName("labourlicenceno")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Ownername)
                    .HasColumnName("ownername")
                    .HasMaxLength(250);

                entity.Property(e => e.Pancard)
                    .HasColumnName("pancard")
                    .HasMaxLength(250);

                entity.Property(e => e.Peliancesno)
                    .HasColumnName("peliancesno")
                    .HasMaxLength(250);

                entity.Property(e => e.Pfregistrationno)
                    .HasColumnName("pfregistrationno")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.Superviorname)
                    .HasColumnName("superviorname")
                    .HasMaxLength(250);

                entity.Property(e => e.Vendorname)
                    .HasColumnName("vendorname")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Countryid)
                    .HasColumnName("countryid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency");

                entity.HasIndex(e => e.Currencyid)
                    .HasName("unique_currency")
                    .IsUnique();

                entity.Property(e => e.Currencyid)
                    .HasColumnName("currencyid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Currencyname)
                    .IsRequired()
                    .HasColumnName("currencyname")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Departmentid)
                    .HasColumnName("departmentid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Departmentdescription)
                    .HasColumnName("departmentdescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Parentdepartmentid).HasColumnName("parentdepartmentid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Departmentlineheadcount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departmentlineheadcount");

                entity.Property(e => e.Contractorassignedheadcount).HasColumnName("contractorassignedheadcount");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Departmentlineheadcountid)
                    .HasColumnName("departmentlineheadcountid")
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Departmentlineid).HasColumnName("departmentlineid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'9999-12-31'::date");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Staffassignedheadcount).HasColumnName("staffassignedheadcount");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Departmentline)
                    .WithMany()
                    .HasForeignKey(d => d.Departmentlineid)
                    .HasConstraintName("fk_dlhc_dl");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.Shiftid)
                    .HasConstraintName("fk_sh_hc");
            });

            modelBuilder.Entity<DepartmentlineheadcountArchive>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departmentlineheadcount_archive");

                entity.Property(e => e.Contractorassignedheadcount).HasColumnName("contractorassignedheadcount");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Departmentlineheadcountid).HasColumnName("departmentlineheadcountid");

                entity.Property(e => e.Departmentlineid).HasColumnName("departmentlineid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Staffassignedheadcount).HasColumnName("staffassignedheadcount");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");
            });

            modelBuilder.Entity<Departmentlinemapping>(entity =>
            {
                entity.HasKey(e => e.Departmentlineid)
                    .HasName("departmentlineid_pkey");

                entity.ToTable("departmentlinemapping");

                entity.Property(e => e.Departmentlineid)
                    .HasColumnName("departmentlineid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasDefaultValueSql("'9999-12-31 00:00:00'::timestamp without time zone");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Parentdepartmentid).HasColumnName("parentdepartmentid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Subdepartmentid).HasColumnName("subdepartmentid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.Departmentlinemapping)
                    .HasForeignKey(d => d.Lineid)
                    .HasConstraintName("fk_line_line");

                entity.HasOne(d => d.Parentdepartment)
                    .WithMany(p => p.DepartmentlinemappingParentdepartment)
                    .HasForeignKey(d => d.Parentdepartmentid)
                    .HasConstraintName("fk_dept_dept");

                entity.HasOne(d => d.Subdepartment)
                    .WithMany(p => p.DepartmentlinemappingSubdepartment)
                    .HasForeignKey(d => d.Subdepartmentid)
                    .HasConstraintName("fk_dept_dept_sub");
            });

            modelBuilder.Entity<DepartmentlinemappingArchive>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departmentlinemapping_archive");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Departmentlineid).HasColumnName("departmentlineid");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Parentdepartmentid).HasColumnName("parentdepartmentid");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Subdepartmentid).HasColumnName("subdepartmentid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("designation");

                entity.Property(e => e.Designationid)
                    .HasColumnName("designationid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Designationdescription)
                    .HasColumnName("designationdescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("education");

                entity.Property(e => e.Educationid)
                    .HasColumnName("educationid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Educationdetails)
                    .IsRequired()
                    .HasColumnName("educationdetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("empid_pkey");

                entity.ToTable("employee");

                entity.HasIndex(e => e.Empcode)
                    .HasName("ux_empcode")
                    .IsUnique();

                entity.HasIndex(e => e.Empid)
                    .HasName("ux_empid")
                    .IsUnique();

                entity.HasIndex(e => new { e.Empid, e.Empcode, e.Firstname, e.Lastname, e.Middlename, e.CurrentPlantid, e.CurrentContractorid, e.CurrentStageid, e.CurrentLineid, e.CurrentDepartmentid, e.CurrentDesignationid, e.Isactive })
                    .HasName("ix_emp");

                entity.HasIndex(e => new { e.Empid, e.Empcode, e.Firstname, e.Lastname, e.Middlename, e.Isactive, e.Dateofjoining, e.Dateofconfirmation, e.Dateofleaving, e.Dateofresignation, e.Dateoflettersubmission, e.Dateofprobation, e.Dateofmarriage, e.Dob })
                    .HasName("ix_emp_dates");

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Accountnumber)
                    .HasColumnName("accountnumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasMaxLength(250);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(250);

                entity.Property(e => e.Alternatemobileno)
                    .HasColumnName("alternatemobileno")
                    .HasMaxLength(20);

                entity.Property(e => e.Attendancemode)
                    .HasColumnName("attendancemode")
                    .HasMaxLength(20);

                entity.Property(e => e.Band)
                    .HasColumnName("band")
                    .HasMaxLength(50);

                entity.Property(e => e.Bankbranch)
                    .HasColumnName("bankbranch")
                    .HasMaxLength(50);

                entity.Property(e => e.Bankname)
                    .HasColumnName("bankname")
                    .HasMaxLength(50);

                entity.Property(e => e.Bloodgroup)
                    .HasColumnName("bloodgroup")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'normal'::character varying");

                entity.Property(e => e.Cardcode)
                    .HasColumnName("cardcode")
                    .HasMaxLength(20);

                entity.Property(e => e.Caste)
                    .HasColumnName("caste")
                    .HasMaxLength(20);

                entity.Property(e => e.CommentsOnEmployeeReliving).HasMaxLength(500);

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.CurrentContractorid).HasColumnName("current_contractorid");

                entity.Property(e => e.CurrentDepartmentid).HasColumnName("current_departmentid");

                entity.Property(e => e.CurrentDesignationid).HasColumnName("current_designationid");

                entity.Property(e => e.CurrentLineid).HasColumnName("current_lineid");

                entity.Property(e => e.CurrentLinemanagerid).HasColumnName("current_linemanagerid");

                entity.Property(e => e.CurrentPlantid)
                    .HasColumnName("current_plantid")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.CurrentRoleid).HasColumnName("current_roleid");

                entity.Property(e => e.CurrentShiftid).HasColumnName("current_shiftid");

                entity.Property(e => e.CurrentStageid).HasColumnName("current_stageid");

                entity.Property(e => e.CurrentStagemanagerid).HasColumnName("current_stagemanagerid");

                entity.Property(e => e.Dateofconfirmation)
                    .HasColumnName("dateofconfirmation")
                    .HasColumnType("date");

                entity.Property(e => e.Dateofjoining)
                    .HasColumnName("dateofjoining")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Dateofleaving)
                    .HasColumnName("dateofleaving")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'9999-12-31'::date");

                entity.Property(e => e.Dateoflettersubmission)
                    .HasColumnName("dateoflettersubmission")
                    .HasColumnType("date");

                entity.Property(e => e.Dateofmarriage)
                    .HasColumnName("dateofmarriage")
                    .HasColumnType("date");

                entity.Property(e => e.Dateofprobation)
                    .HasColumnName("dateofprobation")
                    .HasColumnType("date");

                entity.Property(e => e.Dateofresignation)
                    .HasColumnName("dateofresignation")
                    .HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Educationid).HasColumnName("educationid");

                entity.Property(e => e.Empcode)
                    .IsRequired()
                    .HasColumnName("empcode");

                entity.Property(e => e.Employmenttypeid).HasColumnName("employmenttypeid");

                entity.Property(e => e.Esic)
                    .HasColumnName("esic")
                    .HasColumnType("character varying");

                entity.Property(e => e.Esicapplicable)
                    .HasColumnName("esicapplicable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(1000);

                entity.Property(e => e.Genderid).HasColumnName("genderid");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasMaxLength(20);

                entity.Property(e => e.Groupdoj)
                    .HasColumnName("groupdoj")
                    .HasMaxLength(20);

                entity.Property(e => e.Ibannumber)
                    .HasColumnName("ibannumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Ifsc)
                    .HasColumnName("ifsc")
                    .HasMaxLength(50);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsEligibleForRehire).HasDefaultValueSql("false");

                entity.Property(e => e.IsRehired).HasDefaultValueSql("false");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Ispanaadhaarlinked).HasColumnName("ispanaadhaarlinked");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(1000);

                entity.Property(e => e.LeavingReason).HasMaxLength(500);

                entity.Property(e => e.Lmsreportingmanager1)
                    .HasColumnName("lmsreportingmanager1")
                    .HasMaxLength(50);

                entity.Property(e => e.Lmsreportingmanager2)
                    .HasColumnName("lmsreportingmanager2")
                    .HasMaxLength(50);

                entity.Property(e => e.Lmsreportingmanager3)
                    .HasColumnName("lmsreportingmanager3")
                    .HasMaxLength(50);

                entity.Property(e => e.Lwfapplicable)
                    .HasColumnName("lwfapplicable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Maritalstatusid).HasColumnName("maritalstatusid");

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(1000);

                entity.Property(e => e.Nationid).HasColumnName("nationid");

                entity.Property(e => e.Officialemailaddress)
                    .HasColumnName("officialemailaddress")
                    .HasMaxLength(50);

                entity.Property(e => e.OldEmployeecode)
                    .HasColumnName("old_employeecode")
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100);

                entity.Property(e => e.Paymenttypeid).HasColumnName("paymenttypeid");

                entity.Property(e => e.Payperhour).HasColumnName("payperhour");

                entity.Property(e => e.Permanentcityid).HasColumnName("permanentcityid");

                entity.Property(e => e.Permanentzip)
                    .HasColumnName("permanentzip")
                    .HasMaxLength(10);

                entity.Property(e => e.Personalemailaddress)
                    .HasColumnName("personalemailaddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Pfapplicable)
                    .HasColumnName("pfapplicable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(15);

                entity.Property(e => e.Physicalstatus)
                    .HasColumnName("physicalstatus")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'normal'::character varying");

                entity.Property(e => e.Portal)
                    .HasColumnName("portal")
                    .HasMaxLength(50);

                entity.Property(e => e.Presentcityid).HasColumnName("presentcityid");

                entity.Property(e => e.Presentzip)
                    .HasColumnName("presentzip")
                    .HasMaxLength(10);

                entity.Property(e => e.Professiontaxstate)
                    .HasColumnName("professiontaxstate")
                    .HasMaxLength(20);

                entity.Property(e => e.Ptapplicable)
                    .HasColumnName("ptapplicable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Ptstateid).HasColumnName("ptstateid");

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(500);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(500);

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasMaxLength(20);

                entity.Property(e => e.Remarksforfnf)
                    .HasColumnName("remarksforfnf")
                    .HasMaxLength(50);

                entity.Property(e => e.Residentialnumber)
                    .HasColumnName("residentialnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Salutation)
                    .HasColumnName("salutation")
                    .HasMaxLength(10);

                entity.Property(e => e.Spousename)
                    .HasColumnName("spousename")
                    .HasMaxLength(50);

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .HasMaxLength(8000);

                entity.Property(e => e.Ssntypeid).HasColumnName("ssntypeid");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'newjoinee'::character varying");

                entity.Property(e => e.Subdepartmentid).HasColumnName("subdepartmentid");

                entity.Property(e => e.Tnareportingmanager)
                    .HasColumnName("tnareportingmanager")
                    .HasMaxLength(50);

                entity.Property(e => e.Uan)
                    .HasColumnName("uan")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Visacountry)
                    .HasColumnName("visacountry")
                    .HasMaxLength(20);

                entity.Property(e => e.Visauidnumber)
                    .HasColumnName("visauidnumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Wagescode)
                    .HasColumnName("wagescode")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Companyid)
                    .HasConstraintName("fk_company_emp");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("fk_employee_currency");

                entity.HasOne(d => d.CurrentContractor)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentContractorid)
                    .HasConstraintName("fk_emp_contractor");

                entity.HasOne(d => d.CurrentDepartment)
                    .WithMany(p => p.EmployeeCurrentDepartment)
                    .HasForeignKey(d => d.CurrentDepartmentid)
                    .HasConstraintName("fk_department_employee");

                entity.HasOne(d => d.CurrentDesignation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentDesignationid)
                    .HasConstraintName("fk_designation_emp");

                entity.HasOne(d => d.CurrentLine)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentLineid)
                    .HasConstraintName("fk_emp_line");

                entity.HasOne(d => d.CurrentLinemanager)
                    .WithMany(p => p.InverseCurrentLinemanager)
                    .HasForeignKey(d => d.CurrentLinemanagerid)
                    .HasConstraintName("sk_line_manager");

                entity.HasOne(d => d.CurrentPlant)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentPlantid)
                    .HasConstraintName("fk_employee_plant");

                entity.HasOne(d => d.CurrentRole)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentRoleid)
                    .HasConstraintName("fk_emp_role");

                entity.HasOne(d => d.CurrentShift)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentShiftid)
                    .HasConstraintName("fk_emp_shift");

                entity.HasOne(d => d.CurrentStage)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CurrentStageid)
                    .HasConstraintName("fk_emp_stage");

                entity.HasOne(d => d.CurrentStagemanager)
                    .WithMany(p => p.InverseCurrentStagemanager)
                    .HasForeignKey(d => d.CurrentStagemanagerid)
                    .HasConstraintName("fk_stage_managerid");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Educationid)
                    .HasConstraintName("fk_employee_education");

                entity.HasOne(d => d.Employmenttype)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Employmenttypeid)
                    .HasConstraintName("fk_emptype_emp");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Genderid)
                    .HasConstraintName("fk_gender_employee");

                entity.HasOne(d => d.Maritalstatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Maritalstatusid)
                    .HasConstraintName("fk_maritalstatus_emp");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Nationid)
                    .HasConstraintName("fk_con_emp");

                entity.HasOne(d => d.Paymenttype)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Paymenttypeid)
                    .HasConstraintName("fk_paymenttype_emp");

                entity.HasOne(d => d.Permanentcity)
                    .WithMany(p => p.EmployeePermanentcity)
                    .HasForeignKey(d => d.Permanentcityid)
                    .HasConstraintName("fk_emp_province");

                entity.HasOne(d => d.Presentcity)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Presentcityid)
                    .HasConstraintName("fk_city_employee");

                entity.HasOne(d => d.Ptstate)
                    .WithMany(p => p.EmployeePtstate)
                    .HasForeignKey(d => d.Ptstateid)
                    .HasConstraintName("fk_ptstate_emp");

                entity.HasOne(d => d.Ssntype)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Ssntypeid)
                    .HasConstraintName("fk_con");

                entity.HasOne(d => d.Subdepartment)
                    .WithMany(p => p.EmployeeSubdepartment)
                    .HasForeignKey(d => d.Subdepartmentid)
                    .HasConstraintName("fk_employee_subdept");
            });

            modelBuilder.Entity<EmployeeAttendance>(entity =>
            {
                entity.ToTable("employee_attendance");

                entity.HasIndex(e => new { e.Attendancedate, e.Empid })
                    .HasName("ix_empatt_attendancedate");

                entity.HasIndex(e => new { e.Attendancedate, e.Empid, e.Stageid, e.Shiftid, e.Ispresent })
                    .HasName("ix_empatt_attendancedate_main");

                entity.Property(e => e.Employeeattendanceid)
                    .HasColumnName("employeeattendanceid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Absencereasonid).HasColumnName("absencereasonid");

                entity.Property(e => e.AttendanceTypeId)
                    .HasColumnName("attendance_type_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Attendancedate)
                    .HasColumnName("attendancedate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Breaktime).HasColumnName("breaktime");

                entity.Property(e => e.Checkintime).HasColumnName("checkintime");

                entity.Property(e => e.Checkouttime).HasColumnName("checkouttime");

                entity.Property(e => e.CompOffDate)
                    .HasColumnName("comp_off_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Extraovertimehours).HasColumnName("extraovertimehours");

                entity.Property(e => e.Ispresent).HasColumnName("ispresent");

                entity.Property(e => e.Ot).HasColumnName("ot");

                entity.Property(e => e.Overtimehours).HasColumnName("overtimehours");

                entity.Property(e => e.Payrollshiftid).HasColumnName("payrollshiftid");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Stageid).HasColumnName("stageid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Workedhours).HasColumnName("workedhours");

                entity.HasOne(d => d.Absencereason)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.Absencereasonid)
                    .HasConstraintName("fk_empatt_abs");

                entity.HasOne(d => d.AttendanceType)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.AttendanceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_attendancetype");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_att_emp");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.Shiftid)
                    .HasConstraintName("fk_employee_shift");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.Stageid)
                    .HasConstraintName("fk_employee_stg");
            });

            modelBuilder.Entity<EmployeeAttendanceHist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee_attendance_hist");

                entity.Property(e => e.Absencereasonid).HasColumnName("absencereasonid");

                entity.Property(e => e.AttendanceTypeId).HasColumnName("attendance_type_id");

                entity.Property(e => e.Attendancedate).HasColumnName("attendancedate");

                entity.Property(e => e.Breaktime).HasColumnName("breaktime");

                entity.Property(e => e.Checkintime).HasColumnName("checkintime");

                entity.Property(e => e.Checkouttime).HasColumnName("checkouttime");

                entity.Property(e => e.CompOffDate)
                    .HasColumnName("comp_off_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Employeeattendanceid).HasColumnName("employeeattendanceid");

                entity.Property(e => e.Ispresent).HasColumnName("ispresent");

                entity.Property(e => e.Ot).HasColumnName("ot");

                entity.Property(e => e.Overtimehours).HasColumnName("overtimehours");

                entity.Property(e => e.Payrollshiftid).HasColumnName("payrollshiftid");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Stageid).HasColumnName("stageid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");

                entity.Property(e => e.Workedhours).HasColumnName("workedhours");
            });

            modelBuilder.Entity<EmployeeAttendanceSummary>(entity =>
            {
                entity.ToTable("employee_attendance_summary");

                entity.Property(e => e.Employeeattendancesummaryid)
                    .HasColumnName("employeeattendancesummaryid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Absent).HasColumnName("absent");

                entity.Property(e => e.Attendancedate)
                    .HasColumnName("attendancedate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Present).HasColumnName("present");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.EmployeeAttendanceSummary)
                    .HasForeignKey(d => d.Lineid)
                    .HasConstraintName("fk_att_line");
            });

            modelBuilder.Entity<EmployeeRoleTracker>(entity =>
            {
                entity.HasKey(e => e.Emproletrackerid)
                    .HasName("emproletrackerid_pkey");

                entity.ToTable("employee_role_tracker");

                entity.Property(e => e.Emproletrackerid)
                    .HasColumnName("emproletrackerid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasDefaultValueSql("'9999-12-31 00:00:00'::timestamp without time zone");

                entity.Property(e => e.Ildl).HasColumnName("ildl");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Payperhour).HasColumnName("payperhour");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Subdepartmentid).HasColumnName("subdepartmentid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeRoleTracker)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("fk_department_employee_tarcker");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeRoleTracker)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_emp_role_tra_emp");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRoleTracker)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("fk_emp_role_tra_role");
            });

            modelBuilder.Entity<EmployeeRoleTrackerArchive>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee_role_tracker_archive");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Emproletrackerid).HasColumnName("emproletrackerid");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Payperhour).HasColumnName("payperhour");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");
            });

            modelBuilder.Entity<EmployeeTracker>(entity =>
            {
                entity.HasKey(e => e.Emptrackerid)
                    .HasName("emptrackerid_pkey");

                entity.ToTable("employee_tracker");

                entity.Property(e => e.Emptrackerid)
                    .HasColumnName("emptrackerid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Contractorid).HasColumnName("contractorid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasDefaultValueSql("'9999-12-31 00:00:00'::timestamp without time zone");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Plantid).HasColumnName("plantid");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Stageid).HasColumnName("stageid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Contractorid)
                    .HasConstraintName("fk_emp_contractor");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_emp_tra_emp");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Lineid)
                    .HasConstraintName("fk_emp_tra_line");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Plantid)
                    .HasConstraintName("fk_employeetracker_plant");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Shiftid)
                    .HasConstraintName("fk_shift_employee");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.EmployeeTracker)
                    .HasForeignKey(d => d.Stageid)
                    .HasConstraintName("fk_emp_tra_stage");
            });

            modelBuilder.Entity<EmployeeTrackerArchive>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee_tracker_archive");

                entity.Property(e => e.Contractorid).HasColumnName("contractorid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Emptrackerid).HasColumnName("emptrackerid");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Plantid).HasColumnName("plantid");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Stageid).HasColumnName("stageid");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");
            });

            modelBuilder.Entity<Employeeattendancerefresh>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK_attendance_id");

                entity.ToTable("employeeattendancerefresh");

                entity.Property(e => e.AttendanceId)
                    .HasColumnName("attendance_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Batchid).HasColumnName("batchid");

                entity.Property(e => e.EmpCode).HasColumnName("emp_code");

                entity.Property(e => e.Io)
                    .HasColumnName("io")
                    .HasMaxLength(2);

                entity.Property(e => e.Readername)
                    .HasColumnName("readername")
                    .HasMaxLength(50);

                entity.Property(e => e.Readerno).HasColumnName("readerno");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<Employeedocuments>(entity =>
            {
                entity.HasKey(e => e.Emloyeedocumentsid)
                    .HasName("emloyeedocuments_pkey");

                entity.ToTable("employeedocuments");

                entity.Property(e => e.Emloyeedocumentsid)
                    .HasColumnName("emloyeedocumentsid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Attachmentid).HasColumnName("attachmentid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Employeedocuments1)
                    .IsRequired()
                    .HasColumnName("employeedocuments")
                    .HasColumnType("character varying(500)[]");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.Employeedocuments)
                    .HasForeignKey(d => d.Attachmentid)
                    .HasConstraintName("fk_att_employeedocuments");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Employeedocuments)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_employee_emplyeedocuments");
            });

            modelBuilder.Entity<Employeesalary>(entity =>
            {
                entity.ToTable("employeesalary");

                entity.Property(e => e.Employeesalaryid)
                    .HasColumnName("employeesalaryid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Effectivefrom).HasColumnName("effectivefrom");

                entity.Property(e => e.Effectiveto).HasColumnName("effectiveto");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Esic).HasColumnName("esic");

                entity.Property(e => e.Gross).HasColumnName("gross");

                entity.Property(e => e.Hra).HasColumnName("hra");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Payperday).HasColumnName("payperday");

                entity.Property(e => e.Payperhour).HasColumnName("payperhour");

                entity.Property(e => e.Pf).HasColumnName("pf");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Employeesalary)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_employee_empsalary");
            });

            modelBuilder.Entity<Employeeskill>(entity =>
            {
                entity.ToTable("employeeskill");

                entity.Property(e => e.Employeeskillid)
                    .HasColumnName("employeeskillid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Attendancescore).HasColumnName("attendancescore");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lineleaderrating).HasColumnName("lineleaderrating");

                entity.Property(e => e.Lineleaderscore).HasColumnName("lineleaderscore");

                entity.Property(e => e.Operatorerrors).HasColumnName("operatorerrors");

                entity.Property(e => e.Otherscore)
                    .HasColumnName("otherscore")
                    .HasComment("lineleader score");

                entity.Property(e => e.Ratingdate).HasColumnName("ratingdate");

                entity.Property(e => e.Skillratingscore).HasColumnName("skillratingscore");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Employeeskill)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_EmployeeSkill_Employee");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.Genderid)
                    .HasColumnName("genderid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Genderdescription)
                    .HasColumnName("genderdescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Holidaytype>(entity =>
            {
                entity.ToTable("holidaytype");

                entity.Property(e => e.Holidaytypeid)
                    .HasColumnName("holidaytypeid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Holidaytypedetails)
                    .IsRequired()
                    .HasColumnName("holidaytypedetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Lefthrms>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lefthrms");

                entity.Property(e => e.Dol)
                    .HasColumnName("dol")
                    .HasMaxLength(250);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("line");

                entity.Property(e => e.Lineid)
                    .HasColumnName("lineid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Linedescription)
                    .HasColumnName("linedescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Plantid).HasColumnName("plantid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Line)
                    .HasForeignKey(d => d.Plantid)
                    .HasConstraintName("fk_line_plant");
            });

            modelBuilder.Entity<Loaddata>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loaddata");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Alternatemobileno)
                    .HasColumnName("alternatemobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Attendancegroup)
                    .HasColumnName("attendancegroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Attendancemode)
                    .HasColumnName("attendancemode")
                    .HasMaxLength(250);

                entity.Property(e => e.Attendancemodegroup)
                    .HasColumnName("attendancemodegroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Attendancerulegroup)
                    .HasColumnName("attendancerulegroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Band)
                    .HasColumnName("band")
                    .HasMaxLength(250);

                entity.Property(e => e.Bankaccountno)
                    .HasColumnName("bankaccountno")
                    .HasMaxLength(250);

                entity.Property(e => e.Bankbranch)
                    .HasColumnName("bankbranch")
                    .HasMaxLength(250);

                entity.Property(e => e.Bankname)
                    .HasColumnName("bankname")
                    .HasMaxLength(250);

                entity.Property(e => e.Bloodgroup)
                    .HasColumnName("bloodgroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(250);

                entity.Property(e => e.Calendargroup)
                    .HasColumnName("calendargroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Cardcode)
                    .HasColumnName("cardcode")
                    .HasMaxLength(250);

                entity.Property(e => e.Caste)
                    .HasColumnName("caste")
                    .HasMaxLength(250);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(250);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofconfirmation)
                    .HasColumnName("dateofconfirmation")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofjoining)
                    .HasColumnName("dateofjoining")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofleaving)
                    .HasColumnName("dateofleaving")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateoflettersubmission)
                    .HasColumnName("dateoflettersubmission")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofmarriage)
                    .HasColumnName("dateofmarriage")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofprobation)
                    .HasColumnName("dateofprobation")
                    .HasMaxLength(250);

                entity.Property(e => e.Dateofresignation)
                    .HasColumnName("dateofresignation")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasMaxLength(250);

                entity.Property(e => e.Empcode)
                    .HasColumnName("empcode")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeegroup)
                    .HasColumnName("employeegroup")
                    .HasMaxLength(250);

                entity.Property(e => e.EmploymentType)
                    .HasColumnName("employment_type")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicapplicable)
                    .HasColumnName("esicapplicable")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasMaxLength(250);

                entity.Property(e => e.Gross)
                    .HasColumnName("gross")
                    .HasMaxLength(250);

                entity.Property(e => e.Groupdoj)
                    .HasColumnName("groupdoj")
                    .HasMaxLength(250);

                entity.Property(e => e.Ibannumber)
                    .HasColumnName("ibannumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("ifsccode")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Ispanaadhaarlinked)
                    .HasColumnName("ispanaadhaarlinked")
                    .HasMaxLength(250);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(250);

                entity.Property(e => e.Leavegroup)
                    .HasColumnName("leavegroup")
                    .HasMaxLength(250);

                entity.Property(e => e.Level).HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Lmsreportingmanager1)
                    .HasColumnName("lmsreportingmanager1")
                    .HasMaxLength(250);

                entity.Property(e => e.Lmsreportingmanager2)
                    .HasColumnName("lmsreportingmanager2")
                    .HasMaxLength(250);

                entity.Property(e => e.Lmsreportingmanager3)
                    .HasColumnName("lmsreportingmanager3")
                    .HasMaxLength(250);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.Lwfapplicable)
                    .HasColumnName("lwfapplicable")
                    .HasMaxLength(250);

                entity.Property(e => e.Maritalstatus)
                    .HasColumnName("maritalstatus")
                    .HasMaxLength(250);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(250);

                entity.Property(e => e.Nation)
                    .HasColumnName("nation")
                    .HasMaxLength(250);

                entity.Property(e => e.Officialemailaddress)
                    .HasColumnName("officialemailaddress")
                    .HasMaxLength(250);

                entity.Property(e => e.OldEmployeecode)
                    .HasColumnName("old_employeecode")
                    .HasMaxLength(250);

                entity.Property(e => e.Panno)
                    .HasColumnName("panno")
                    .HasMaxLength(250);

                entity.Property(e => e.Paymentmode)
                    .HasColumnName("paymentmode")
                    .HasMaxLength(250);

                entity.Property(e => e.Permanentaddress)
                    .HasColumnName("permanentaddress")
                    .HasMaxLength(250);

                entity.Property(e => e.Permanentcity)
                    .HasColumnName("permanentcity")
                    .HasMaxLength(250);

                entity.Property(e => e.Permanentcountry)
                    .HasColumnName("permanentcountry")
                    .HasMaxLength(250);

                entity.Property(e => e.Permanentpincode)
                    .HasColumnName("permanentpincode")
                    .HasMaxLength(250);

                entity.Property(e => e.Permanentstate)
                    .HasColumnName("permanentstate")
                    .HasMaxLength(250);

                entity.Property(e => e.Personalemailaddress)
                    .HasColumnName("personalemailaddress")
                    .HasMaxLength(250);

                entity.Property(e => e.Pfapplicable)
                    .HasColumnName("pfapplicable")
                    .HasMaxLength(250);

                entity.Property(e => e.Pfbasesalarylimit)
                    .HasColumnName("pfbasesalarylimit")
                    .HasMaxLength(250);

                entity.Property(e => e.PhysicalStatus)
                    .HasColumnName("physical_status")
                    .HasMaxLength(250);

                entity.Property(e => e.Portal)
                    .HasColumnName("portal")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentaddress)
                    .HasColumnName("presentaddress")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentcity)
                    .HasColumnName("presentcity")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentcountry)
                    .HasColumnName("presentcountry")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentmobilenumber)
                    .HasColumnName("presentmobilenumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentpincode)
                    .HasColumnName("presentpincode")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentstate)
                    .HasColumnName("presentstate")
                    .HasMaxLength(250);

                entity.Property(e => e.Professiontaxstate)
                    .HasColumnName("professiontaxstate")
                    .HasMaxLength(250);

                entity.Property(e => e.Ptapplicable)
                    .HasColumnName("ptapplicable")
                    .HasMaxLength(250);

                entity.Property(e => e.Ptstate)
                    .HasColumnName("ptstate")
                    .HasMaxLength(250);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(250);

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasMaxLength(250);

                entity.Property(e => e.Remarksforfnf)
                    .HasColumnName("remarksforfnf")
                    .HasMaxLength(250);

                entity.Property(e => e.Reportingmanager)
                    .HasColumnName("reportingmanager")
                    .HasMaxLength(250);

                entity.Property(e => e.Residentialnumber)
                    .HasColumnName("residentialnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Roledesignation)
                    .HasColumnName("roledesignation")
                    .HasMaxLength(250);

                entity.Property(e => e.Salutation)
                    .HasColumnName("salutation")
                    .HasMaxLength(250);

                entity.Property(e => e.Shift)
                    .HasColumnName("shift")
                    .HasMaxLength(250);

                entity.Property(e => e.Spousename)
                    .HasColumnName("spousename")
                    .HasMaxLength(250);

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .HasMaxLength(250);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Tnareportingmanager)
                    .HasColumnName("tnareportingmanager")
                    .HasMaxLength(250);

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.Uanno)
                    .HasColumnName("uanno")
                    .HasMaxLength(250);

                entity.Property(e => e.Visacountry)
                    .HasColumnName("visacountry")
                    .HasMaxLength(250);

                entity.Property(e => e.Visauidnumber)
                    .HasColumnName("visauidnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Wagescode)
                    .HasColumnName("wagescode")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loaddatafa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loaddatafa");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Sampleline)
                    .HasColumnName("sampleline")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loaddatalcm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loaddatalcm");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Sampleline)
                    .HasColumnName("sampleline")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loadempdata>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loadempdata");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Contractname)
                    .HasColumnName("contractname")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasMaxLength(250);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(250);

                entity.Property(e => e.Doj)
                    .HasColumnName("doj")
                    .HasMaxLength(250);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicnumber)
                    .HasColumnName("esicnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Jobrole)
                    .HasColumnName("jobrole")
                    .HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(250);

                entity.Property(e => e.Shift)
                    .HasColumnName("shift")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("uannumber")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loadtest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loadtest");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasMaxLength(250);

                entity.Property(e => e.Contractname)
                    .HasColumnName("contractname")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(250);

                entity.Property(e => e.Doj)
                    .HasColumnName("doj")
                    .HasMaxLength(250);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicnumber)
                    .HasColumnName("esicnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwageperday)
                    .HasColumnName("rateofwageperday")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwagepermonth)
                    .HasColumnName("rateofwagepermonth")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("uannumber")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loadtest1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loadtest1");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasMaxLength(250);

                entity.Property(e => e.Contractname)
                    .HasColumnName("contractname")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(250);

                entity.Property(e => e.Doj)
                    .HasColumnName("doj")
                    .HasMaxLength(250);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicnumber)
                    .HasColumnName("esicnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwageperday)
                    .HasColumnName("rateofwageperday")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwagepermonth)
                    .HasColumnName("rateofwagepermonth")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("uannumber")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loadtest2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loadtest2");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasMaxLength(250);

                entity.Property(e => e.Contractname)
                    .HasColumnName("contractname")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(250);

                entity.Property(e => e.Doj)
                    .HasColumnName("doj")
                    .HasMaxLength(250);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicnumber)
                    .HasColumnName("esicnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwageperday)
                    .HasColumnName("rateofwageperday")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwagepermonth)
                    .HasColumnName("rateofwagepermonth")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("uannumber")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Loadtest3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("loadtest3");

                entity.Property(e => e.Aadharno)
                    .HasColumnName("aadharno")
                    .HasMaxLength(250);

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasMaxLength(250);

                entity.Property(e => e.Contractname)
                    .HasColumnName("contractname")
                    .HasMaxLength(250);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasMaxLength(250);

                entity.Property(e => e.Doj)
                    .HasColumnName("doj")
                    .HasMaxLength(250);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(250);

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasMaxLength(250);

                entity.Property(e => e.Esicnumber)
                    .HasColumnName("esicnumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Fathername)
                    .HasColumnName("fathername")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(250);

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasMaxLength(250);

                entity.Property(e => e.Ildl)
                    .HasColumnName("ildl")
                    .HasMaxLength(250);

                entity.Property(e => e.Line)
                    .HasColumnName("line")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(250);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwageperday)
                    .HasColumnName("rateofwageperday")
                    .HasMaxLength(250);

                entity.Property(e => e.Rateofwagepermonth)
                    .HasColumnName("rateofwagepermonth")
                    .HasMaxLength(250);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartment)
                    .HasColumnName("subdepartment")
                    .HasMaxLength(250);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("uannumber")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Maritalstatus>(entity =>
            {
                entity.ToTable("maritalstatus");

                entity.Property(e => e.Maritalstatusid)
                    .HasColumnName("maritalstatusid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Maritalstatus1)
                    .HasColumnName("maritalstatus")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<OtStatus>(entity =>
            {
                entity.ToTable("ot_status");

                entity.Property(e => e.Otstatusid)
                    .HasColumnName("otstatusid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Otstatusdescription)
                    .IsRequired()
                    .HasColumnName("otstatusdescription")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Paymenttype>(entity =>
            {
                entity.ToTable("paymenttype");

                entity.Property(e => e.Paymenttypeid)
                    .HasColumnName("paymenttypeid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Paymenttype1)
                    .HasColumnName("paymenttype")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("payroll");

                entity.Property(e => e.Payrollid)
                    .HasColumnName("payrollid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Arrearsbasic).HasColumnName("arrearsbasic");

                entity.Property(e => e.Arrearsearnedbasic).HasColumnName("arrearsearnedbasic");

                entity.Property(e => e.Arrearsearnedgross).HasColumnName("arrearsearnedgross");

                entity.Property(e => e.Arrearsearnedhra).HasColumnName("arrearsearnedhra");

                entity.Property(e => e.Arrearsgross).HasColumnName("arrearsgross");

                entity.Property(e => e.Arrearsholidaypresent).HasColumnName("arrearsholidaypresent");

                entity.Property(e => e.Arrearshra).HasColumnName("arrearshra");

                entity.Property(e => e.Arrearsnightshiftallowances).HasColumnName("arrearsnightshiftallowances");

                entity.Property(e => e.Arrearsnonothours).HasColumnName("arrearsnonothours");

                entity.Property(e => e.Arrearsothours).HasColumnName("arrearsothours");

                entity.Property(e => e.Arrearsotpay).HasColumnName("arrearsotpay");

                entity.Property(e => e.Arrearspayperday).HasColumnName("arrearspayperday");

                entity.Property(e => e.Arrearspayperhour).HasColumnName("arrearspayperhour");

                entity.Property(e => e.Arrearsweekoffpresent).HasColumnName("arrearsweekoffpresent");

                entity.Property(e => e.Arrearsworkeddays).HasColumnName("arrearsworkeddays");

                entity.Property(e => e.Asubtotalgrosswage).HasColumnName("asubtotalgrosswage");

                entity.Property(e => e.Attendanceincentive).HasColumnName("attendanceincentive");

                entity.Property(e => e.Bsubtotalstatuory).HasColumnName("bsubtotalstatuory");

                entity.Property(e => e.Canteen).HasColumnName("canteen");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Csubtotal).HasColumnName("csubtotal");

                entity.Property(e => e.Ctc).HasColumnName("ctc");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.Currentbasic).HasColumnName("currentbasic");

                entity.Property(e => e.Currentearnedbasic).HasColumnName("currentearnedbasic");

                entity.Property(e => e.Currentearnedgross).HasColumnName("currentearnedgross");

                entity.Property(e => e.Currentearnedhra).HasColumnName("currentearnedhra");

                entity.Property(e => e.Currentgross).HasColumnName("currentgross");

                entity.Property(e => e.Currentholidaypresent).HasColumnName("currentholidaypresent");

                entity.Property(e => e.Currenthra).HasColumnName("currenthra");

                entity.Property(e => e.Currentnightshiftallowances).HasColumnName("currentnightshiftallowances");

                entity.Property(e => e.Currentnonothours).HasColumnName("currentnonothours");

                entity.Property(e => e.Currentothours).HasColumnName("currentothours");

                entity.Property(e => e.Currentotpay).HasColumnName("currentotpay");

                entity.Property(e => e.Currentpayperday).HasColumnName("currentpayperday");

                entity.Property(e => e.Currentpayperhour).HasColumnName("currentpayperhour");

                entity.Property(e => e.Currentweekoffpresent).HasColumnName("currentweekoffpresent");

                entity.Property(e => e.Currentworkeddays).HasColumnName("currentworkeddays");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Esicemployee).HasColumnName("esicemployee");

                entity.Property(e => e.Esicemployer).HasColumnName("esicemployer");

                entity.Property(e => e.Grosswages).HasColumnName("grosswages");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Leavewithwage).HasColumnName("leavewithwage");

                entity.Property(e => e.Netamount).HasColumnName("netamount");

                entity.Property(e => e.Nonothours).HasColumnName("nonothours");

                entity.Property(e => e.Otherallowances).HasColumnName("otherallowances");

                entity.Property(e => e.Otherdeduction).HasColumnName("otherdeduction");

                entity.Property(e => e.Othours).HasColumnName("othours");

                entity.Property(e => e.Pfemployee).HasColumnName("pfemployee");

                entity.Property(e => e.Pfemployer).HasColumnName("pfemployer");

                entity.Property(e => e.Pt).HasColumnName("pt");

                entity.Property(e => e.Ratingallowances).HasColumnName("ratingallowances");

                entity.Property(e => e.Refundabledeposit).HasColumnName("refundabledeposit");

                entity.Property(e => e.Servicecharge).HasColumnName("servicecharge");

                entity.Property(e => e.Totaldeduction).HasColumnName("totaldeduction");

                entity.Property(e => e.Totalworkingdays).HasColumnName("totalworkingdays");

                entity.Property(e => e.Transport).HasColumnName("transport");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Workeddays).HasColumnName("workeddays");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Payroll)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("fk_payrollid_currencyid");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Payroll)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("fk_employee_payrollid");
            });

            modelBuilder.Entity<Payrollconfig>(entity =>
            {
                entity.ToTable("payrollconfig");

                entity.Property(e => e.Payrollconfigid)
                    .HasColumnName("payrollconfigid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");

                entity.Property(e => e.Attendanceincentive).HasColumnName("attendanceincentive");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Esic).HasColumnName("esic");

                entity.Property(e => e.Hra).HasColumnName("hra");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Nightshiftallowance).HasColumnName("nightshiftallowance");

                entity.Property(e => e.Otperhour).HasColumnName("otperhour");

                entity.Property(e => e.Payrollstatusid).HasColumnName("payrollstatusid");

                entity.Property(e => e.Pf).HasColumnName("pf");

                entity.Property(e => e.Professionaltax1500).HasColumnName("professionaltax_1500");

                entity.Property(e => e.Professionaltax2000).HasColumnName("professionaltax_2000");
                entity.Property(e => e.Uploadedfilelocation).HasColumnName("uploadedfilelocation");


                entity.Property(e => e.ReviewedBy).HasColumnName("reviewed_by");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Payrollstatus)
                    .WithMany(p => p.Payrollconfig)
                    .HasForeignKey(d => d.Payrollstatusid)
                    .HasConstraintName("fk_payrollconfig_payrollstatus");
            });

            modelBuilder.Entity<Payrolldeduction>(entity =>
            {
                entity.HasKey(e => e.Pdid)
                    .HasName("payrolldeduction_pkey");

                entity.ToTable("payrolldeduction");

                entity.Property(e => e.Pdid)
                    .HasColumnName("pdid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Canteendeductions).HasColumnName("canteendeductions");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Empcode).HasColumnName("empcode");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Lcmeligible).HasColumnName("lcmeligible");

                entity.Property(e => e.Miscellaneous).HasColumnName("miscellaneous");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("character varying");

                entity.Property(e => e.Monthnumber).HasColumnName("monthnumber");

                entity.Property(e => e.Otherallowance).HasColumnName("otherallowance");

                entity.Property(e => e.Otherdeduction).HasColumnName("otherdeduction");

                entity.Property(e => e.Ratingallowances).HasColumnName("ratingallowances");

                entity.Property(e => e.Refundabledeposit).HasColumnName("refundabledeposit");

                entity.Property(e => e.Subleaderallowance).HasColumnName("subleaderallowance");

                entity.Property(e => e.Transportdeductions).HasColumnName("transportdeductions");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.EmpcodeNavigation)
                    .WithMany(p => p.Payrolldeduction)
                    .HasPrincipalKey(p => p.Empcode)
                    .HasForeignKey(d => d.Empcode)
                    .HasConstraintName("fk_payrolldeduction_employee");
            });

            modelBuilder.Entity<Payrollshift>(entity =>
            {
                entity.ToTable("payrollshift");

                entity.Property(e => e.Payrollshiftid)
                    .HasColumnName("payrollshiftid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Iscreatedbyhr).HasColumnName("iscreatedbyhr");

                entity.Property(e => e.Isedited).HasColumnName("isedited");

                entity.Property(e => e.Maxshiftendtime)
                    .HasColumnName("maxshiftendtime")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Plantid).HasColumnName("plantid");

                entity.Property(e => e.Shiftactivedate).HasColumnName("shiftactivedate");

                entity.Property(e => e.Shiftdetails)
                    .IsRequired()
                    .HasColumnName("shiftdetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Shiftendtime)
                    .HasColumnName("shiftendtime")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftid).HasColumnName("shiftid");

                entity.Property(e => e.Shiftstartthresholdfrom)
                    .HasColumnName("shiftstartthresholdfrom")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftstartthresholdto)
                    .HasColumnName("shiftstartthresholdto")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftstarttime)
                    .HasColumnName("shiftstarttime")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Payrollshift)
                    .HasForeignKey(d => d.Plantid)
                    .HasConstraintName("fk_payrollshift_plant");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Payrollshift)
                    .HasForeignKey(d => d.Shiftid)
                    .HasConstraintName("fk_payrollshift_shift");
            });

            modelBuilder.Entity<Payrollstatus>(entity =>
            {
                entity.ToTable("payrollstatus");

                entity.Property(e => e.Payrollstatusid)
                    .HasColumnName("payrollstatusid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Payrollstatus1)
                    .HasColumnName("payrollstatus")
                    .HasColumnType("character varying");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.ToTable("plant");

                entity.Property(e => e.Plantid)
                    .HasColumnName("plantid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Plantdescription)
                    .HasColumnName("plantdescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Plantlocation)
                    .HasColumnName("plantlocation")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Provinceid)
                    .HasColumnName("provinceid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Province1)
                    .HasColumnName("province")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_prov_country");
            });

            modelBuilder.Entity<RadiantHoliday>(entity =>
            {
                entity.HasKey(e => e.Holidayid)
                    .HasName("holiday_pkey");

                entity.ToTable("radiant_holiday");

                entity.Property(e => e.Holidayid)
                    .HasColumnName("holidayid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Holiday)
                    .HasColumnName("holiday")
                    .HasColumnType("date");

                entity.Property(e => e.Holidaytypeid).HasColumnName("holidaytypeid");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Holidaytype)
                    .WithMany(p => p.RadiantHoliday)
                    .HasForeignKey(d => d.Holidaytypeid)
                    .HasConstraintName("radiant_holiday_holidaytypeid_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Roledetails)
                    .IsRequired()
                    .HasColumnName("roledetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Screendetails)
                    .HasColumnName("screendetails")
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Screens>(entity =>
            {
                entity.HasKey(e => e.Screenid)
                    .HasName("screen_pkey");

                entity.ToTable("screens");

                entity.Property(e => e.Screenid)
                    .HasColumnName("screenid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shift");

                entity.Property(e => e.Shiftid)
                    .HasColumnName("shiftid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Plantid).HasColumnName("plantid");

                entity.Property(e => e.Shiftactivedate).HasColumnName("shiftactivedate");

                entity.Property(e => e.Shiftdetails)
                    .IsRequired()
                    .HasColumnName("shiftdetails")
                    .HasMaxLength(250);

                entity.Property(e => e.Shiftendtime)
                    .HasColumnName("shiftendtime")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftinactivedate).HasColumnName("shiftinactivedate");

                entity.Property(e => e.Shiftstartthresholdfrom)
                    .HasColumnName("shiftstartthresholdfrom")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftstartthresholdto)
                    .HasColumnName("shiftstartthresholdto")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Shiftstarttime)
                    .HasColumnName("shiftstarttime")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Shift)
                    .HasForeignKey(d => d.Plantid)
                    .HasConstraintName("fk_shift_plant");
            });

            modelBuilder.Entity<Ssntype>(entity =>
            {
                entity.ToTable("ssntype");

                entity.Property(e => e.Ssntypeid)
                    .HasColumnName("ssntypeid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Ssntypedetails)
                    .IsRequired()
                    .HasColumnName("ssntypedetails")
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("stage");

                entity.Property(e => e.Stageid)
                    .HasColumnName("stageid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lineid).HasColumnName("lineid");

                entity.Property(e => e.Stagedescription)
                    .HasColumnName("stagedescription")
                    .HasMaxLength(250);

                entity.Property(e => e.Subdepartmentid).HasColumnName("subdepartmentid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.StageDepartment)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("fk_stg_dept");

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.Stage)
                    .HasForeignKey(d => d.Lineid)
                    .HasConstraintName("fk_line_stage");

                entity.HasOne(d => d.Subdepartment)
                    .WithMany(p => p.StageSubdepartment)
                    .HasForeignKey(d => d.Subdepartmentid)
                    .HasConstraintName("fk_stg_subdept");
            });

            modelBuilder.Entity<SupplyType>(entity =>
            {
                entity.ToTable("supply_type");

                entity.Property(e => e.Supplytypeid)
                    .HasColumnName("supplytypeid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Typedetails)
                    .IsRequired()
                    .HasColumnName("typedetails")
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasColumnType("character varying");

                entity.Property(e => e.Employeename)
                    .HasColumnName("employeename")
                    .HasColumnType("character varying");

                entity.Property(e => e.Lastworkingday)
                    .HasColumnName("lastworkingday")
                    .HasColumnType("character varying");

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasColumnType("character varying");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
