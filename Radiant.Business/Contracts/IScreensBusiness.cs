using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IScreensBusiness : IGenericBusiness<ScreensDto>
    {
        Task<List<ScreensDto>> GetScreensByIds(List<long> Ids);
    }
}
