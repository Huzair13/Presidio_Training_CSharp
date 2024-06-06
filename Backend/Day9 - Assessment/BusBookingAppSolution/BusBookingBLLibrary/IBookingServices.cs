using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingBLLibrary
{
    public interface IBookingServices
    {
        int AddBusRoute(Route route);
        List<Route> SearchBuses(string origin, string destination, DateTime date);
        bool BookTicket(Booking booking);
        bool CancelBooking(int bookingID);
        List<Route> GetAllRoutes();
        List<Route> GetAllRoutes(string origin, string destination);
        void PrintBookingDetailsById(int bookingID);
    }
}
