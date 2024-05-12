using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Exceptions
{
    public class InValidIdException :Exception
    {
        string msg;
        public InValidIdException()
        {
            msg = "Entered ID is Invalid";
        }
        public override string Message => msg;
    }
}
