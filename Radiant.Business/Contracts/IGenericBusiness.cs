using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IGenericBusiness<T> : IBusiness
    {
        Task<List<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> GetByName(string name);
        Task<T> Create(T item);
        Task<T> Edit(T item);
        Task Delete(long id);
    }
}
