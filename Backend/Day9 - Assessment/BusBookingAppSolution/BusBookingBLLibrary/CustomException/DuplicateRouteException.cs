using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary.CustomException
{
    public class DuplicateRouteException :Exception
    {
        string msg;
        public DuplicateRouteException()
        {
            msg = "Route with the entered Router ID already exists";
        }
        public override string Message => msg;
    }
}
