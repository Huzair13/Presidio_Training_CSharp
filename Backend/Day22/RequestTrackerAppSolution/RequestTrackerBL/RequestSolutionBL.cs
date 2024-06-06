using RequestTrackerDALLibrary;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary.Exceptions;

namespace RequestTrackerBL
{
    public class RequestSolutionBL : IRequestSolutionBL
    {
        private readonly IRepository<int, RequestSolution> _repository;
        public RequestSolutionBL()
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<IList<RequestSolution>> GetAllSolutionsAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<RequestSolution> GetSolutionByRequestId(int requestId)
        {
            var allRequests = await _repository.GetAll();
            var results = allRequests.FirstOrDefault(r => r.RequestId == requestId);

            if (results != null)
            {
                return results;
            }
            throw new InValidIdException();
            
        }

        public async Task<RequestSolution> GiveSolutionToRequestAsync(RequestSolution requestSolution)
        {
            try
            {
                var result = await _repository.Add(requestSolution);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<RequestSolution> AddCommentsToTheSolutions(int requestId, int solutionId,string comment)
        {
            var solution = await GetSolutionByRequestId(requestId);
            solution.RequestRaiserComment= comment;
            return await _repository.Update(solution); 
        }
    }
}
