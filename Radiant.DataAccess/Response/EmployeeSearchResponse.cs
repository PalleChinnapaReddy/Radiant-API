using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.DataAccess.Response
{
    public class EmployeeSearchResponse
    {
        public int TotalRows { get; set; }
        public List<Employee> Data { get; set; }
    }
}
