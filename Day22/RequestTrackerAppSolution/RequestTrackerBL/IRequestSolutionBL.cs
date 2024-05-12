using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public interface IRequestSolutionBL
    {
        public Task<RequestSolution> GiveSolutionToRequestAsync(RequestSolution requestSolution);
        public Task<IList<RequestSolution>> GetAllSolutionsAsync();
        public Task<RequestSolution> GetSolutionByRequestId(int requestId);
        public Task<RequestSolution> AddCommentsToTheSolutions(int requestId,int solutionId,string comments);
    }
}
