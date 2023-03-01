using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByName(string name);
        Task<T> GetById(long id);
        Task<T> Create(T record);
        Task<T> Edit( T record);
        Task Delete(long id);
    }
}
