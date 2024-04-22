using BusBookingDALLibrary;
using BusBookingModelLibrary;

using BusBookingBLLibrary.CustomException;
namespace BusBookingBLLibrary
{
    public class BusBookingBL : IBookingServices
    {
        private readonly UserService _userService;
        private readonly IRepository<int,Route> _routeRepository;
        private readonly IRepository<int,Booking> _bookingRepository;

        public BusBookingBL()
        {
            _routeRepository = new BusRouteRepository();
            _bookingRepository = new BusBookingRepository();
            _userService = new UserService();
        }


        //ADD ROUTE
        public int AddBusRoute(Route route)
        {
            if (route == null)
                throw new ArgumentNullException(nameof(route), "Bus route cannot be null");

            if (_routeRepository.Get(route.RouteID) != null)
                throw new DuplicateRouteException();

            var addedRoute = _routeRepository.Add(route);
            return addedRoute != null ? addedRoute.RouteID : -1;
        }

        //GET ALL ROUTES
        public List<Route> GetAllRoutes(string origin, string destination)
        {
            List<Route> allRoutes = _routeRepository.GetAll();

            // Filter routes based on origin and destination
            List<Route> filteredRoutes = allRoutes.Where(route => route.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase)
                                                              && route.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                                                  .ToList();

            return filteredRoutes;
        }


        //BOOK BUS TICKET
        public bool BookTicket(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking), "Booking cannot be null");

            Route selectedRoute = booking.SelectedBus; 
            if (selectedRoute == null)
            {
                Console.WriteLine("Invalid selected route.");
                throw new InvalidRouteSelectionException();
            }

            List<Route> allRoutes = _routeRepository.GetAll();
            Route selectedBus = allRoutes.Find(route => route.RouteID == selectedRoute.RouteID);

            if (selectedBus != null && selectedBus.AvailableSeats >= booking.NumberOfSeatsBooked && 
                selectedBus.DepartureTime.Date == booking.DepartureDate.Date)
            {
                selectedBus.AvailableSeats -= booking.NumberOfSeatsBooked;
                _bookingRepository.Add(booking);

                Console.WriteLine($"Booking Successful! Your Booking ID is: {booking.BookingID}");
                return true;
            }
            else
            {
                return false; 
            }
        }


        //cancel the booking
        public bool CancelBooking(int bookingID)
        {
            Booking bookingToCancel = null;

            // Find the booking with the matching booking ID
            foreach (Booking booking in _bookingRepository.GetAll())
            {
                if (booking.BookingID == bookingID)
                {
                    bookingToCancel = booking;
                    break;
                }
            }

            if (bookingToCancel == null)
            {
                return false;
            }

            // Increase the available seats for the booked bus
            bookingToCancel.SelectedBus.AvailableSeats += bookingToCancel.NumberOfSeatsBooked;

            // delete  the booking
            bookingToCancel.Status = "Cancelled";
            bookingToCancel.Payment = "Refunded";

            if (bookingToCancel.Payment == "Refunded")
            {
                _bookingRepository.Delete(bookingToCancel.GetHashCode());
            }
            return true; 
        }

        //Search Buses
        public List<Route> SearchBuses(string origin, string destination, DateTime date)
        {
            List<Route> allRoutes = _routeRepository.GetAll();
            List<Route> matchingRoutes = allRoutes.FindAll(route =>
                route.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                route.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                route.DepartureTime.Date == date.Date);
            if (matchingRoutes != null)
            {
                return matchingRoutes;
            }
            throw new NoRoutesFoundException();
        }

        //Get All available Routes
        public List<Route> GetAllRoutes()
        {
            List<Route> AllRoutes = _routeRepository.GetAll();
            if (AllRoutes.Count != 0)
            {
                return _routeRepository.GetAll();
            }
            throw new NoRoutesFoundException();
        }

        public Booking GetBookingByID(int bookingID)
        {

            List<Booking> allBookings = _bookingRepository.GetAll();
            foreach (Booking booking in allBookings)
            {
                if (booking.BookingID == bookingID)
                {
                    return booking;
                }
            }

            return null;
        }

        //Print Booking Details by Booking ID
        public void PrintBookingDetailsById(int bookingID)
        {
            Booking booking = GetBookingByID(bookingID);
            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            Console.WriteLine($"Booking ID: {booking.BookingID}");
            Console.WriteLine($"Passenger Name: {booking.PassengerName}");
            Console.WriteLine($"Contact Information: {booking.MobileNumber}");
            Console.WriteLine($"Origin: {booking.SelectedBus.Origin}");
            Console.WriteLine($"Destination: {booking.SelectedBus.Destination}");
            Console.WriteLine($"Departure Date: {booking.DepartureDate}");
            Console.WriteLine($"Number of Seats Booked: {booking.NumberOfSeatsBooked}");
            Console.WriteLine($"Status: {booking.Status}");
        }
    }
}
