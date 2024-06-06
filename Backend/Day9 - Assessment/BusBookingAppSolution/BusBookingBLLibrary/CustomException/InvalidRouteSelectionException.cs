using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary.CustomException
{
    public class InvalidRouteSelectionException :Exception
    {
        string msg;
        public InvalidRouteSelectionException()
        {
            msg = "Route is invalid";
        }
        public override string Message => msg;

    }
}
