using Microsoft.EntityFrameworkCore;
using RequestTrackerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public virtual async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int RequestId)
        {
            var request = await Get(RequestId);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
                return request;
            }
            throw new RequestNotFoundException();
            
        }

        public async Task<Request> Get(int RequestId)
        {
            var request = _context.Requests.SingleOrDefault(e => e.RequestNumber == RequestId);
            if (request != null)
            {
                return request;
            }
            throw new RequestNotFoundException();
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return request;
            }
            throw new RequestNotFoundException();
        }
    }
}
