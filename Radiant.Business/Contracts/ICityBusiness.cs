using Radiant.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface ICityBusiness : IGenericBusiness<CityDto>
    {
        Task<List<CityDto>> GetCitiesByStateId(long stateid);
    }
}
