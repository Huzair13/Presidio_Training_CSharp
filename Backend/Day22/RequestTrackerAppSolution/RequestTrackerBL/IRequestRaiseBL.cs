using RequestTrackerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public interface IRequestRaiseBL
    {
        public Task<Request> RaiseRequestAsync(Request request);
        public Task<IList<Request>> GetAllRequestAsyc();
        public Task<IList<Request>> GetRequestsByEmployeeIDAsync(int RequestID);
        public Task<Request> CloseRequestAsync(int RequestID,int ClosedByEmployeeId);
        public Task<string> ViewRequestStatusByIdAsync(int RequestID);
        public Task<Request> GetRequestByRquestId(int requestId);
    }
}
