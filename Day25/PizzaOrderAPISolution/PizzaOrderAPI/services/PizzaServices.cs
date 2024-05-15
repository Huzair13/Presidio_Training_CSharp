using PizzaOrderAPI.Exceptions;
using PizzaOrderAPI.Interfaces;
using PizzaOrderAPI.Models;

namespace PizzaOrderAPI.services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaServices(IRepository<int, Pizza> reposiroty)
        {
            _repository = reposiroty;
        }

        public async Task<Pizza> DeletePizzaById(int id)
        {
            var pizza = await _repository.Delete(id);
            if(pizza != null)
            {
                return pizza;
            }
            throw new NoPizzasFoundException();
        }

        public async Task<IEnumerable<Pizza>> GetAllPizza()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() == 0)
                throw new NoPizzasFoundException();
            return pizzas;
        }

        public async Task<IEnumerable<Pizza>> GetAvailablePizza()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() != 0)
            {
                var availablePizza = pizzas.Where(piz => piz.PizzasInStock > 0);
                return availablePizza;
            }
            throw new NoPizzasFoundException();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _repository.Get(id);
            if (pizza != null)
            {
                return pizza;
            }
            throw new NoPizzasFoundException();
        }

        public async Task<Pizza> GetPizzaByName(string name)
        {
            var pizzas = await _repository.Get();
            var pizza = pizzas.FirstOrDefault(p => p.Name == name);
            if(pizza != null)
            {
                return pizza;
            }
            throw new NoPizzasFoundException();
        }

        public async Task<Pizza> UpdatePizza(Pizza pizza)
        {
            var Updatedpizza = await _repository.Update(pizza);
            if (pizza != null) 
            { 
                return Updatedpizza;
            }
            throw new NoPizzasFoundException();
        }

    }
}
