namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoEmployeesFoundException :Exception
    {
        string msg;
        public NoEmployeesFoundException()
        {
            msg = "No Employees Found";
        }
        public override string Message => msg;
    }
}
