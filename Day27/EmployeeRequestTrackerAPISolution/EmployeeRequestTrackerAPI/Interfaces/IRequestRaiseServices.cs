using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestRaiseServices
    {
        public Task<IEnumerable<ReturnRequestDTO>> GetAllRequestAsyc();
        public Task<IEnumerable<ReturnRequestDTO>> GetRequestsByEmployeeIDAsync(int RequestID);
        public Task<ReturnRequestDTO> CloseRequestAsync(CloseRequestDTO closeRequestDTO);
        public Task<string> ViewRequestStatusByIdAsync(int RequestID);
        public Task<Request> GetRequestByRquestId(int requestId);
        public Task<Request> RaiseRequestAsync(RaiseRequestDTO raiseRequestDTO);
    }
}
