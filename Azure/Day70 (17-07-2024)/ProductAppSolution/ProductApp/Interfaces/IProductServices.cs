using ProductApp.Models;

namespace ProductApp.Interfaces
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductByID(int id);
        public Task<Product> GetProductByName(string name);
    }
}
