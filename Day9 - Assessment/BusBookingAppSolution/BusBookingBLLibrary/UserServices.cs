using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary
{
    using System;

    public enum UserRole
    {
        Administrator,
        User,
        Guest
    }

    public class UserService
    {
        private UserRole _currentUserRole;

        public bool AuthenticateUser(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                _currentUserRole = UserRole.Administrator;
                return true;
            }
            else if (username == "user" && password == "user")
            {
                _currentUserRole = UserRole.User;
                return true;
            }
            else if (username == "guest" && password == "guest")
            {
                _currentUserRole = UserRole.Guest;
                return true;
            }
            else
            {
                return false; 
            }
        }

        public bool CanCancelOrBookTicket()
        {
            // Only admin and users can cancel or book the tickets
            return _currentUserRole == UserRole.Administrator || _currentUserRole == UserRole.User;
        }

        public bool CanAddRoutes()
        {
            //only admin can add the routes
            return _currentUserRole == UserRole.Administrator;
        }
    }
}
