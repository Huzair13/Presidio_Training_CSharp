using BusBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingDALLibrary
{
    public class BusRouteRepository : IRepository<int, Route>
    {
        private readonly Dictionary<int, Route> _routes;
        public BusRouteRepository()
        {
            _routes = new Dictionary<int, Route>();
        }

        //Add Bus Routes
        public Route Add(Route item)
        {
            if (!_routes.ContainsKey(item.RouteID))
            {
                _routes.Add(item.RouteID, item);
                return item;
            }
            return null;
        }

        //Delete Bus Routes
        public Route Delete(int key)
        {
            if (_routes.ContainsKey(key))
            {
                var route = _routes[key];
                _routes.Remove(key);
                return route;
            }
            return null;
        }

        //Get Bus Route by ID
        public Route Get(int key)
        {
            return _routes.ContainsKey(key) ? _routes[key] : null;
        }

        //Get All bus routes
        public List<Route> GetAll()
        {
            return new List<Route>(_routes.Values);
        }

        //Update Bus Routes
        public Route Update(Route item)
        {
            if (_routes.ContainsKey(item.RouteID))
            {
                _routes[item.RouteID] = item;
                return item;
            }
            return null;
        }
    }
}
