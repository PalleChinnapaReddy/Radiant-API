using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IScreensRepository : IGenericRepository<Screens>
    {
        Task<List<Screens>> GetScreensByIds(List<long> Ids);
    }
}
