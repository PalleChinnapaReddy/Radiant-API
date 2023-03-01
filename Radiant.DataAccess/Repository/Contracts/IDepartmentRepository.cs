using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<List<DepartmentWiseAttendanceReport>> GetDepartmentWiseReport(DateTime date);

        Task<List<Department>> GetByParent(long? parentId);
        Task<long?> GetLineIdFromMapping(long departmentId);
    }
}
