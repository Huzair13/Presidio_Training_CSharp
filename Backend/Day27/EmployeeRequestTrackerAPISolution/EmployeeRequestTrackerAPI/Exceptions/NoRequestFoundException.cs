namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoRequestFoundException : Exception
    {
        string msg;
        public NoRequestFoundException() 
        {
            msg = "No Requests Foound";
        }
        public override string Message => msg;
    }
}
