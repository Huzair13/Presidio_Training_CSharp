using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Exceptions
{
    public  class RequestNotFoundException : Exception
    {
        string msg;

        public RequestNotFoundException()
        {
            msg = "Request Not Found Check the Request ID";
        }

        public override string Message => msg;
    }
}
