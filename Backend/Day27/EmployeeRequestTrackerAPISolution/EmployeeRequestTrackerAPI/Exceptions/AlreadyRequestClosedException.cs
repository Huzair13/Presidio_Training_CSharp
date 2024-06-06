namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class AlreadyRequestClosedException : Exception
    {
        string msg;
        public AlreadyRequestClosedException()
        {
            msg = "Request is already Closed";
        }
        public override string Message => msg; 
    }
}
