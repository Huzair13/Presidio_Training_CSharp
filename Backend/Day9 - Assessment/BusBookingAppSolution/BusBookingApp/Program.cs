using BusBookingModelLibrary;
using BusBookingBLLibrary;
namespace BusBookingApp
{
    public class Program
    {

        static IBookingServices bookingServices;

        // 1) Add Routes
        static void AddRoutes()
        {
            Console.WriteLine("\nEnter route details:");
            Console.Write("Route ID: ");
            int routeID = int.Parse(Console.ReadLine());
            Console.Write("Origin: ");
            string origin = Console.ReadLine();
            Console.Write("Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Departure Time (yyyy-MM-dd HH:mm): ");
            DateTime departureTime;
            if (!DateTime.TryParse(Console.ReadLine(), out departureTime))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd HH:mm.");
                return;
            }
            Console.Write("Available Seats: ");
            int availableSeats;
            if (!int.TryParse(Console.ReadLine(), out availableSeats))
            {
                Console.WriteLine("Invalid input. Please enter a number for available seats.");
                return;
            }

            Route newRoute = new Route
            {
                RouteID = routeID,
                Origin = origin,
                Destination = destination,
                DepartureTime = departureTime,
                AvailableSeats = availableSeats
            };

            int addedRoute = bookingServices.AddBusRoute(newRoute);
            if (addedRoute != -1)
            {
                Console.WriteLine("Route added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add route. Route ID may already exist.");
            }
        }

        //2) Search Buses
        static void SearchBuses()
        {
            //origin city name
            Console.Write("Enter origin city: ");
            string origin = Console.ReadLine().Trim();

            //destination city name
            Console.Write("Enter destination city: ");
            string destination = Console.ReadLine().Trim(); 

            //departure city name
            Console.Write("Enter departure date (MM/dd/yyyy): ");
            string dateInput = Console.ReadLine().Trim(); 

            //departure date
            if (!DateTime.TryParseExact(dateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format MM/dd/yyyy.");
                return;
            }

            //Searching Buses by calling searchBuses in BusBookingBLLibrary
            List<Route> availableBuses = bookingServices.SearchBuses(origin, destination, date);

            Console.WriteLine($"\nAvailable Buses from {origin} to {destination} on {date.ToShortDateString()}:");

            if (availableBuses.Count == 0)
            {
                Console.WriteLine("No available buses found for the provided route and date.");
            }
            else
            {
                foreach (var bus in availableBuses)
                {
                    Console.WriteLine($"RouteID: {bus.RouteID}, Origin: {bus.Origin}, Destination: {bus.Destination}, Departure Time: {bus.DepartureTime}, Available Seats: {bus.AvailableSeats}");
                }
            }
        }


        //3) Book Tickets
        static void BookTicket()
        {
            //Passenger name
            Console.Write("Enter passenger name: ");
            string passengerName = Console.ReadLine();

            //Mobile Number
            Console.Write("Enter Mobile Number with 91: ");
            string mobileNumStr = Console.ReadLine();
            long contactInfo = 0;
            if (mobileNumStr.Length == 12)
            {
                if (!long.TryParse(mobileNumStr, out contactInfo))
                {
                    Console.WriteLine("Invalid Mobile Number. Please enter a valid long integer.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("your mobile number should not be less than 12 digits including country code");
                return;
            }

            //Origin City 
            Console.Write("Enter origin city: ");
            string origin = Console.ReadLine();

            //Destination city
            Console.Write("Enter destination city: ");
            string destination = Console.ReadLine();

            // Find available routes based on origin and destination
            List<Route> availableRoutes = bookingServices.GetAllRoutes(origin, destination);
            if (availableRoutes.Count == 0)
            {
                Console.WriteLine("No available routes found for the Entered origin and destination.");
                return;
            }

            // Print available routes for selection
            Console.WriteLine("Available Routes:");
            foreach (var route in availableRoutes)
            {
                Console.WriteLine($"RouteID: {route.RouteID}, Origin: {route.Origin}, Destination: {route.Destination}, Departure Time: {route.DepartureTime}, Available Seats: {route.AvailableSeats}");
            }

            //Departure date
            Console.Write("Enter departure date (MM/dd/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            //Number of seats
            Console.Write("Enter number of seats to book: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfSeats))
            {
                Console.WriteLine("Invalid number of seats.");
                return;
            }

            //Route ID
            Console.Write("Enter the RouteID of the selected route: ");
            if (!int.TryParse(Console.ReadLine(), out int selectedRouteID))
            {
                Console.WriteLine("Invalid RouteID.");
                return;
            }

            // Create the booking with the selected route
            Booking booking = new Booking
            {
                PassengerName = passengerName,
                MobileNumber = contactInfo,
                SelectedBus = availableRoutes.FirstOrDefault(route => route.RouteID == selectedRouteID),
                DepartureDate = date,
                NumberOfSeatsBooked = numberOfSeats
            };

            //Book Tickets
            bool isBookingSuccessful = bookingServices.BookTicket(booking);
            if (isBookingSuccessful)
            {
                Console.WriteLine("Booking Successful!");
            }
            else
            {
                Console.WriteLine("Booking Failed! No available seats or invalid bus selection.");
            }
        }


        //4) Cancel Booking
        static void CancelBooking()
        {
            //Booking ID
            Console.Write("Enter Booking ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bookingID))
            {
                Console.WriteLine("Invalid Booking ID.");
                return;
            }

            //cancel
            bool isCancellationSuccessful = bookingServices.CancelBooking(bookingID);
            if (isCancellationSuccessful)
            {
                Console.WriteLine("Booking Cancelled Successfully!");
            }
            else
            {
                Console.WriteLine("Booking Cancellation Failed! Booking ID not found.");
            }
        }


        //5) Print All Routes
        static void PrintAllRoutes()
        {
            List<Route> allRoutes = bookingServices.GetAllRoutes();

            if (allRoutes == null || allRoutes.Count == 0)
            {
                Console.WriteLine("No routes available.");
            }
            else
            {
                Console.WriteLine("Available Bus Routes:");
                foreach (var route in allRoutes)
                {
                    Console.WriteLine($"RouteID: {route.RouteID}, Origin: {route.Origin}, Destination: {route.Destination}, Departure Time: {route.DepartureTime}, Available Seats: {route.AvailableSeats}");
                }
            }
        }


        //6) Print the booking details by the given ID
        private static void PrintBookingDetailsByID()
        {
            Console.Write("Enter Booking ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bookingID))
            {
                Console.WriteLine("Invalid Booking ID.");
                return;
            }
            bookingServices.PrintBookingDetailsById(bookingID);
        }


        static void AddSampleRoutes()
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Add sample bus routes for testing with future departure dates
            Route route1 = new Route { RouteID = 1, Origin = "City A", Destination = "City B", DepartureTime = today.AddDays(7), AvailableSeats = 50 };
            Route route2 = new Route { RouteID = 2, Origin = "City B", Destination = "City C", DepartureTime = today.AddDays(14), AvailableSeats = 40 };

            bookingServices.AddBusRoute(route1);
            bookingServices.AddBusRoute(route2);
        }

        

        static void Main(string[] args)
        {

            UserService userService = new UserService();

            // Simulate user authentication
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            if (userService.AuthenticateUser(username, password))
            {
                // Initialize Bus Booking System
                bookingServices = new BusBookingBL();

                // Add sample routes for testing
                AddSampleRoutes();

                // Menu loop
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nBus Booking System Menu:");
                    Console.WriteLine("1. Add Routes");
                    Console.WriteLine("2. Search for available buses");
                    Console.WriteLine("3. Book a ticket");
                    Console.WriteLine("4. Cancel a booking");
                    Console.WriteLine("5. Print All Available Routes");
                    Console.WriteLine("6. Print the booking details by Booking ID");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice (1-7): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            if (userService.CanAddRoutes())
                            {
                                AddRoutes();
                            }
                            else
                            {
                                Console.WriteLine("Only Admin can add the routes, You are restricted from adding the routes");
                            }
                            break;
                        case "2":
                            SearchBuses();
                            break;
                        case "3":
                            if (userService.CanCancelOrBookTicket())
                            {
                                BookTicket();
                            }
                            else
                            {
                                Console.WriteLine("Guest are restricted from cancelling the ticket you can View the Routes available and Booking details with booking ID");
                            }
                            break;
                        case "4":
                            if (userService.CanCancelOrBookTicket())
                            {
                                CancelBooking();
                            }
                            else
                            {
                                Console.WriteLine("Guest are restricted from cancelling the ticket you can View the Routes available and Booking details with booking ID");
                            }
                            break;
                        case "5":
                            PrintAllRoutes();
                            break;
                        case "6":
                            PrintBookingDetailsByID();
                            break;
                        case "7":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }

                Console.WriteLine("Exiting Bus Booking System. Have a great day!");
            }
            else
            {
                Console.WriteLine("Authentication failed. Please try again.");
            }


        }


    }
}
