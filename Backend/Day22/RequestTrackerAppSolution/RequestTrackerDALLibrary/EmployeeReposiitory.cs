using RequestTrackerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary.Exceptions;


namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            throw new NoEmployeeFoundException();
        }

        public virtual async Task<Employee> Get(int employeeID)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == employeeID);
            if(employee != null)
            {
                return employee;
            }
            throw new NoEmployeeFoundException();
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.Id);
            if (employee != null)
            {
                _context.Entry<Employee>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return employee;
            }
            throw new NoEmployeeFoundException();
            
        }
    }
}
