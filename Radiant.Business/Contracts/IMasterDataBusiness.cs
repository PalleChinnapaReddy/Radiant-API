using Radiant.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IMasterDataBusiness
    {
        Task<List<MaritalstatusDto>> GetMartialStatus();
        Task<List<PaymenttypeDto>> GetPaymenttypes();
        Task<List<CityDto>> GetCities();
        Task<List<AttachmentsDto>> GetAttachments();

    }
}
