using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Exceptions
{
    public class UserNotFoundException :Exception
    {
        string msg;
        public UserNotFoundException()
        {
            msg = "User Not Found";
        }
        public override string Message => msg;
    }
}
