using PizzaOrderAPI.Models;
using System.Numerics;

namespace PizzaOrderAPI.Interfaces
{
    public interface IPizzaServices
    {
        public Task<IEnumerable<Pizza>> GetAllPizza();
        public Task<IEnumerable<Pizza>> GetAvailablePizza();
        public Task<Pizza> GetPizzaByName(string name);
        public Task<Pizza> DeletePizzaById(int id);
        public Task<Pizza> UpdatePizza(Pizza pizza);
        public Task<Pizza> GetPizzaById(int id);
    }
}
