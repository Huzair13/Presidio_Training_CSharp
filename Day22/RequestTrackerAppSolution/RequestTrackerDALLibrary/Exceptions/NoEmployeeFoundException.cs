using System;

namespace RequestTrackerDALLibrary.Exceptions
{
    public class NoEmployeeFoundException : Exception
    {
        string msg;

        public NoEmployeeFoundException()
        {
            msg = "Employee Not Found Check the Employee ID";
        }

        public override string Message => msg;
    }
}
