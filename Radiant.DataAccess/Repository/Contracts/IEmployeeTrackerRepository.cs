using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IEmployeeTrackerRepository: IGenericRepository<EmployeeTracker>
    {
        Task<List<EmployeeTracker>> CreateAll(List<EmployeeTracker> holidays);
    }
}
