using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestRaiseService : IRequestRaiseServices
    {
        private readonly IReposiroty<int, Request> _repository;

        public RequestRaiseService(IReposiroty<int, Request> reposiroty)
        {
            _repository = reposiroty;
        }

        public async Task<ReturnRequestDTO> CloseRequestAsync(CloseRequestDTO closeRequestDTO)
        {
            Request request = await _repository.Get(closeRequestDTO.RequestID);
            if (request == null)
            {
                throw new NoRequestFoundException();
            }
            if(request.RequestStatus == "Closed")
            {
                throw new AlreadyRequestClosedException();
            }
            request.RequestStatus = "Closed";
            request.ClosedDate = DateTime.Now;
            request.RequestClosedBy = closeRequestDTO.RequestClosedBy;

            var results = await _repository.Update(request);
            ReturnRequestDTO returnRequestDTO = MapReturnRequestRequestDTOToCloseRequest(results);

            return returnRequestDTO;
        }

        private ReturnRequestDTO MapReturnRequestRequestDTOToCloseRequest(Request request)
        {
            ReturnRequestDTO returnRequestDTO = new ReturnRequestDTO();
            returnRequestDTO.Id = request.Id;
            returnRequestDTO.RequestMessage = request.RequestMessage;
            returnRequestDTO.RequestDate = request.RequestDate;
            returnRequestDTO.ClosedDate = request.ClosedDate;
            returnRequestDTO.RequestStatus = request.RequestStatus;
            returnRequestDTO.RequestRaisedBy = request.RequestRaisedBy;
            returnRequestDTO.RequestClosedBy = request.RequestClosedBy;
            return returnRequestDTO;
        }

        public async Task<IEnumerable<ReturnRequestDTO>> GetAllRequestAsyc()
        {
            var result= await _repository.Get();
            if (result.Count() == 0)
            {
                throw new NoRequestFoundException();
            }

            IEnumerable<ReturnRequestDTO> returnRequestDTO = MapReturnRequestRequestDTOToRequest(result);
            return returnRequestDTO;
        }

        private IEnumerable<ReturnRequestDTO> MapReturnRequestRequestDTOToRequest(IEnumerable<Request> result)
        {
            IEnumerable<ReturnRequestDTO> returnRequestDTOs = new List<ReturnRequestDTO>();

            foreach (var item in result)
            {
                ReturnRequestDTO returnRequestDTO = new ReturnRequestDTO
                {
                    Id = item.Id,
                    RequestMessage = item.RequestMessage,
                    RequestDate = item.RequestDate,
                    ClosedDate = item.ClosedDate,
                    RequestStatus = item.RequestStatus,
                    RequestRaisedBy = item.RequestRaisedBy,
                    RequestClosedBy = item.RequestClosedBy
                };

                returnRequestDTOs = returnRequestDTOs.Concat(new[] { returnRequestDTO });
            }
            return returnRequestDTOs;
        }

        public async Task<Request> GetRequestByRquestId(int requestId)
        {
            var results = await _repository.Get(requestId);
            return results;

        }
        public async Task<IEnumerable<ReturnRequestDTO>> GetRequestsByEmployeeIDAsync(int employeeId)
        {
            var results = await _repository.Get();

            var requestsByEmployee = results.Where(r => r.RequestRaisedBy == employeeId).ToList();
            if(requestsByEmployee.Count() == 0) 
            {
                throw new NoRequestFoundException();
            }
            IEnumerable<ReturnRequestDTO> returnRequestDTO = MapReturnRequestRequestDTOToRequest(requestsByEmployee);

            return returnRequestDTO;
        }

        public async Task<Request> RaiseRequestAsync(RaiseRequestDTO raiseRequestDTO)
        {
            Request request = await MapRequestRaiseDTOToRequest(raiseRequestDTO);
            var result = await _repository.Add(request);
            return result;
        }

        private async Task<Request> MapRequestRaiseDTOToRequest(RaiseRequestDTO raiseRequestDTO)
        {
            Request request = new Request();
            request.RequestMessage=raiseRequestDTO.RequestMessage;
            request.RequestRaisedBy = raiseRequestDTO.RequestRaisedBy;
            request.RequestDate = DateTime.Now;
            request.RequestStatus = "Open";

            return request;

        }

        public async Task<string> ViewRequestStatusByIdAsync(int RequestID)
        {
            var result = await _repository.Get(RequestID);

            return result.RequestStatus;
        }

    }
}
