using ProductApp.Exceptions;
using ProductApp.Interfaces;
using ProductApp.Models;

namespace ProductApp.services
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<int, Product> _repository;

        public ProductServices(IRepository<int, Product> reposiroty)
        {
            _repository = reposiroty;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() == 0)
                throw new NoProductFoundException();
            return pizzas;
        }

        public async Task<Product> GetProductByID(int id)
        {
            var pizza = await _repository.Get(id);
            if (pizza != null)
            {
                return pizza;
            }
            throw new NoProductFoundException();
        }

        public async Task<Product> GetProductByName(string name)
        {
            var pizzas = await _repository.Get();
            var pizza = pizzas.FirstOrDefault(p => p.Name == name);
            if (pizza != null)
            {
                return pizza;
            }
            throw new NoProductFoundException();
        }

    }
}
