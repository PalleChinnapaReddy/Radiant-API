namespace Radiant.Business.Models
{
    public class DepartmentWiseAttendanceReportDto
    {
        public string DepartmentName { get; set; }
        public long? ContractorAssigned { get; set; }
        public long? StaffAssigned { get; set; }
        public long? Assigned { get; set; }
        public long? ContactorPresent { get; set; }
        public long? StaffPresent { get; set; }
        public long? Preset { get; set; }
        public long? ContractorPerc { get; set; }
        public long? StaffPerc { get; set; }
        public long? TotalPerc { get; set; }
    }
}
