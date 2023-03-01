using System;
using System.Collections.Generic;
using System.Text;

namespace Radiant.Business.Models.CustomizedAPI
{
    public class AssignedHeadCountRequestDto
    {
        public AssignedHeadCountRequestDto()
        {
            DepartmentIds = "-1";
        }

        public string DepartmentIds { get; set; }
        public string ShiftId { get; set; }
        public DateTime Date { get; set; }
    }
}
