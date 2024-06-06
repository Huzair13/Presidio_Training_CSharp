using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary
{
    public interface IUserServices
    {
        bool AuthenticateUser(string username, string password);
        bool CanAddRoutes();
        bool CanCancelOrBookTicket();
    }
}
