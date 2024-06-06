using RequestTrackerDALLibrary;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IRepository<int, SolutionFeedback> _repository;
        public FeedbackBL()
        {
            IRepository<int, SolutionFeedback> repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback)
        {
            return await _repository.Add(feedback);
        }

        public async Task<SolutionFeedback> DeleteFeedbackById(int feedbackId)
        {
            return await _repository.Delete(feedbackId);
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedback()
        {
            return await _repository.GetAll();
        }

        public async Task<SolutionFeedback> GetFeedbackBySolutionId(int solutionId)
        {
            var result = await _repository.Get(solutionId);
            return result;
        }

        public async Task<SolutionFeedback> UpdateFeedback(SolutionFeedback feedback)
        {
            return await _repository.Update(feedback);
        }
    }
}
