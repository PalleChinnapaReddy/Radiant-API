using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface ISearchableRepository<T1, T2> : IGenericRepository<T1>
    {
        Task<List<T1>> Search(T2 searchCriteria);
    }
}
