using RequestTrackerDALLibrary;
using RequestTrackerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBL
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRequestRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Employee> changeRole(Employee employee)
        {
            return await _repository.Update(employee);
        }

        public async Task<Employee> getUserDetails(int employeeId)
        {
            var userDetails = await  _repository.Get(employeeId);
            return userDetails;
        }

        public async Task<bool> Login(Employee employee)
        {
            var emp = await _repository.Get(employee.Id);
            if (emp != null)
            {
                if (emp.Password == employee.Password)
                    return true;
            }
            return false;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var result = await _repository.Add(employee);
            return result;
        }

        public async Task<Employee> Unregister(int employeeId)
        {
            var result = await _repository.Delete(employeeId);
            return result;
        }
    }
}
