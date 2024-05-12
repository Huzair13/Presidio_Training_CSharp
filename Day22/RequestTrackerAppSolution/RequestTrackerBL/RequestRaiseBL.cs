using RequestTrackerDALLibrary;
using RequestTrackerDALLibrary.Exceptions;
using RequestTrackerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public class RequestRaiseBL : IRequestRaiseBL
    {
        private readonly IRepository<int, Request> _repository;
        public RequestRaiseBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<Request> CloseRequestAsync(int RequestID,int ClosedByEmployeeId)
        {
            Request request = await _repository.Get(RequestID);
            request.RequestStatus = "Closed";
            request.ClosedDate = DateTime.Now;
            request.RequestClosedBy=ClosedByEmployeeId;
            return await _repository.Update(request);
        }

        public async Task<IList<Request>> GetAllRequestAsyc()
        {
            return await _repository.GetAll();
        }

        public async Task<Request> GetRequestByRquestId(int requestId)
        {
            var results = await _repository.Get(requestId);
            return results;

        }
        public async Task<IList<Request>> GetRequestsByEmployeeIDAsync(int employeeId)
        {
            var results = await _repository.GetAll();
            
            var requestsByEmployee = results.Where(r => r.RequestRaisedBy == employeeId).ToList();

            return requestsByEmployee;
        }

        public async Task<Request> RaiseRequestAsync(Request request)
        {
            var result = await _repository.Add(request);
            return result;
        }

        public async Task<string> ViewRequestStatusByIdAsync(int RequestID)
        {
            var result = await _repository.Get(RequestID);

            return result.RequestStatus;
        }
    }
}
