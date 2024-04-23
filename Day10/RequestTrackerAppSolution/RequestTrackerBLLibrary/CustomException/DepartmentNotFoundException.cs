using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.CustomException
{
    public class DepartmentNotFoundException : Exception
    {
        string message;
        public DepartmentNotFoundException()
        {
            message = "No Department with such name";
        }
        public DepartmentNotFoundException(string name)
        {
            message = "No Department with name {name}";
        }
        public override string Message => message;
    }
}
