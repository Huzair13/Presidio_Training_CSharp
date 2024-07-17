using Microsoft.EntityFrameworkCore;
using ProductApp.contexts;
using ProductApp.Exceptions;
using ProductApp.Interfaces;
using ProductApp.Models;

namespace ProductApp.Repositories
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Product> Delete(int productID)
        {
            var product = await Get(productID);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync(true);
                return product;
            }
            throw new NoProductFoundException();
        }

        public async Task<Product> Get(int productID)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == productID);
            return product;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _context.Products.ToListAsync();
            return products;

        }

        public async Task<Product> Update(Product item)
        {
            var product = await Get(item.Id);
            if (product != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return product;
            }
            throw new NoProductFoundException();
        }
    }
}
