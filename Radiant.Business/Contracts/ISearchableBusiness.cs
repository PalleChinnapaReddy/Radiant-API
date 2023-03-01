using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface ISearchableBusiness<T1, T2> : IGenericBusiness<T1>
    {
        Task<List<T1>> Search(T2 searchDto);
    }
}
