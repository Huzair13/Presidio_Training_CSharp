using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary.CustomException
{
    public class NoRoutesFoundException : Exception
    {
        string msg;
        public NoRoutesFoundException()
        {
            msg = "No Matching Routes Found ";
        }
        public override string Message => msg;
    }
}
