namespace BusBookingModelLibrary
{
    public class Route
    {
        public int RouteID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public Route()
        {
            RouteID = 0;
            Origin = string.Empty;
            Destination = string.Empty;
            DepartureTime = DateTime.MinValue;
            AvailableSeats = 0;
        }

        public Route(int routeID, String origin, String destination,
            DateTime departureTime,int availableSeats)
        {
            RouteID=routeID;
            Origin=origin;
            Destination=destination;
            DepartureTime=departureTime;
            AvailableSeats = availableSeats;
        }
    }


}
