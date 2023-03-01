using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Response
{
    public class EmployeeLinesDashboardResponse
    {
        public int TotalRows { get; set; }
        public List<EmployeeLinesDashboard> Data { get; set; }
    }
}
