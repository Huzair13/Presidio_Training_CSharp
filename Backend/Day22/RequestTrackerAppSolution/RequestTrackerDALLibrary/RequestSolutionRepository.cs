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
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int solutionId)
        {
            var solution = await Get(solutionId);
            if (solution != null)
            {
                _context.RequestSolutions.Remove(solution);
                await _context.SaveChangesAsync();
                return solution;
            }
            throw new SolutionNotFoundException();
        }

        public async Task<RequestSolution> Get(int solutionId)
        {
            var solution = _context.RequestSolutions.SingleOrDefault(s => s.SolutionId == solutionId);
            if (solution!=null)
            {
                return solution;
            }
            throw new SolutionNotFoundException();
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var solution = await Get(entity.SolutionId);
            if (solution != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return solution;
            }
            throw new SolutionNotFoundException();
        }
    }
}
