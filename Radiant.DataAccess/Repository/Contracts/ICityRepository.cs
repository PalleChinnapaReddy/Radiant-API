using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<List<City>> GetCitiesByStateId(long stateid);
    }
}
