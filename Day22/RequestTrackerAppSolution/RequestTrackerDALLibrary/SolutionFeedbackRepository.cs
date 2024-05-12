using Microsoft.EntityFrameworkCore;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int feedbackId)
        {
            var feedback = await Get(feedbackId);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }
            throw new FeedbackNotFoundException();
        }

        public async Task<SolutionFeedback> Get(int feedbackId)
        {
            var feedback = _context.Feedbacks.SingleOrDefault(f => f.FeedbackId == feedbackId);
            if(feedback != null)
            {
                return feedback;
            }
            throw new FeedbackNotFoundException();
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var feedback = await Get(entity.FeedbackId);
            if (feedback != null)
            {
                _context.Entry<SolutionFeedback>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return feedback;
            }
            throw new FeedbackNotFoundException();
        }
    }
}
