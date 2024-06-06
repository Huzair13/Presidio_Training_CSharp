namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NotLoggedInException :Exception
    {
        string msg;
        public NotLoggedInException()
        {
            msg = "User Not Logged In";
        }
        public override string Message => msg;
    }
}
