using Radiant.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IMasterDataRepository
    {
        Task<List<Maritalstatus>> GetMartialStatus();
        Task<List<Paymenttype>> GetPaymenttypes();
        Task<List<City>> GetCities();
        Task<List<Attachments>> GetAttachments();
    }
}
