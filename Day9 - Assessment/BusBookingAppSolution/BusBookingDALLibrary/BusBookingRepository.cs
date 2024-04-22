using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingDALLibrary
{
    public class BusBookingRepository : IRepository<int, Booking>
    {
        private readonly Dictionary<int, Booking> _bookings;
        public BusBookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }

        //Add Booking
        public Booking Add(Booking item)
        {
            if (!_bookings.ContainsKey(item.GetHashCode()))
            {
                _bookings.Add(item.GetHashCode(), item);
                return item;
            }
            return null;
        }

        //Delete Booking
        public Booking Delete(int key)
        {
            if (_bookings.ContainsKey(key))
            {
                var booking = _bookings[key];
                _bookings.Remove(key);
                return booking;
            }
            return null;
        }

        //Get Booking by key
        public Booking Get(int key)
        {
            return _bookings.ContainsKey(key) ? _bookings[key] : null;
        }

        //Get All Bookings
        public List<Booking> GetAll()
        {
            return new List<Booking>(_bookings.Values);
        }

        //Update Bookings
        public Booking Update(Booking item)
        {
            if (_bookings.ContainsKey(item.GetHashCode()))
            {
                _bookings[item.GetHashCode()] = item;
                return item;
            }
            return null;
        }
    }
}
