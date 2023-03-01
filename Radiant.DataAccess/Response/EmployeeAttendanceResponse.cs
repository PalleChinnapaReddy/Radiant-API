using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Response
{
    public class EmployeeAttendanceResponse
    {
        public int TotalRows { get; set; }
        public List<EmployeeAttendance> Data { get; set; }
    }
}
