using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusBookingModelLibrary
{
    public class Booking
    {
        private static int nextBookingID = 101;

        public int BookingID { get; private set; }
        public int BookingId { get; set; }
        public string PassengerName { get; set; }
        public long MobileNumber { get; set; }
        public Route SelectedBus { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberOfSeatsBooked { get; set; }
        public string Status { get; set; }
        public string Payment { get; set; }


        public Booking()
        {
            BookingID = nextBookingID++; // Assign the next booking ID and increment for the next booking
            Status = "Active";
            Payment = "Done";
        }

        public Booking(string passengerName, long mobileNumber, Route selectedBus, 
            DateTime departureDate, int numberOfSeatsBooked)
        {
            PassengerName = passengerName;
            MobileNumber = mobileNumber;
            SelectedBus = selectedBus;
            DepartureDate = departureDate;
            NumberOfSeatsBooked = numberOfSeatsBooked;
            BookingID = nextBookingID++;
            Status = "Active";
        }
    }
}
