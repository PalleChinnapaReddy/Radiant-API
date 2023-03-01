using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IAttendanceOTApprovalBusiness:IGenericBusiness<AttendanceOtApprovalDto>
    {
        Task<AttendanceOTApprovalResponseDto> GetRequestsByManagerId(AttendanceOtSearchDto searchDto);
    }
}
