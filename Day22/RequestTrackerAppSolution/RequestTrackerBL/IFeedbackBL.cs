using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public interface IFeedbackBL
    {
        public Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback);
        public Task<SolutionFeedback> UpdateFeedback(SolutionFeedback feedback);
        public Task<SolutionFeedback> DeleteFeedbackById(int feedbackId);
        public Task<SolutionFeedback> GetFeedbackBySolutionId(int solutionId);
        public Task<IList<SolutionFeedback>> GetAllFeedback();

    }
}
