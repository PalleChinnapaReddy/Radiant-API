using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Response;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IAttendanceOTApprovalRepository:IGenericRepository<AttendanceOtApproval>
    {
        Task<AttendanceOTApprovalResponse> GetRequestsByManagerId(AttendanceOtSearch filterModel);
    }
}
