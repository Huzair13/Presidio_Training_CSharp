namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string msg;
        public NoSuchEmployeeException()
        {
            msg = "No Employee Found";
        }
        public override string Message => msg;
    }
}
