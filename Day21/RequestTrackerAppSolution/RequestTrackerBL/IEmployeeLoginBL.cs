﻿using RequestTrackerLibrary;

namespace RequestTrackerBL
{
    public interface IEmployeeLoginBL
    {
        public Task<bool> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}
