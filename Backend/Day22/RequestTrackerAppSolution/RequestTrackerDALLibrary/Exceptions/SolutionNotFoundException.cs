using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Exceptions
{
    public class SolutionNotFoundException : Exception
    {
        string msg;

        public SolutionNotFoundException()
        {
            msg = "Solution Not Found Check the Solution ID";
        }

        public override string Message => msg;
    }
}
