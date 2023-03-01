namespace Radiant.Business.Models
{
    public class DayAttendanceReportDto
    {
        public string ShiftName { get; set; }
        public int? SNo { get; set; }
        public string DepartmentName { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentType { get; set; }
        public long? ContractorDirect { get; set; }
        public long? ContractorIndirect { get; set; }
        public long? StaffDirect { get; set; }
        public long? StaffIndirect { get; set; }
        public long? TotalDirect { get; set; }
        public long? GTotatILDL { get; set; }
        public long? TotalIndirect { get; set; }
        public string LineName { get; set; }
        public long? ContractorAssigned { get; set; }
        public long? StaffAssigned { get; set; }
        public long? ParentDepartmentId { get; set; }
        public long? LineId { get; set; }
        public long? DisplayOrder { get; set; }
    }
}
