using System;

namespace Radiant.Business.Models
{
    public partial class EmployeeattendancerefreshDto
    {
        public long? EmpCode { get; set; }
        public DateTime? Time { get; set; }
        public long? Readerno { get; set; }
        public string Readername { get; set; }
        public string Io { get; set; }
        public long AttendanceId { get; set; }
        public long? Batchid { get; set; }

    }
}
