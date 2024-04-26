using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartAlreadyExistsForTheGivenCustomer : Exception
    {
        string msg;
        public CartAlreadyExistsForTheGivenCustomer()
        {
            msg = "Cart for the customer already exists";
        }
        public override string Message => msg;
    }
}
