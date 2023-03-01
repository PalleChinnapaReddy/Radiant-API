using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IDepartmentBusiness : IGenericBusiness<DepartmentDto>
    {
        Task<List<DepartmentWiseAttendanceReportDto>> GetDepartmentWiseReport(DateTime date);
        Task<List<DepartmentDto>> GetByParent(int? parentId);
        Task<long?> GetLineIdFromMapping(long departmentId);
    }
}
