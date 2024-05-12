using RequestTrackerLibrary;

namespace RequestTrackerBL
{
    public interface IEmployeeLoginBL
    {
        public Task<bool> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
        public Task<Employee> Unregister(int employeeId);
        public Task<Employee> getUserDetails(int employeeId);
        public Task<Employee> changeRole(Employee employee);
    }
}
