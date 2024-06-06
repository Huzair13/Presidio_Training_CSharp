using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Exceptions
{
    public class FeedbackNotFoundException :Exception
    {
        string msg;

        public FeedbackNotFoundException()
        {
            msg = "Feedback Not Found Check the Feedback ID";
        }

        public override string Message => msg;
    }
}
