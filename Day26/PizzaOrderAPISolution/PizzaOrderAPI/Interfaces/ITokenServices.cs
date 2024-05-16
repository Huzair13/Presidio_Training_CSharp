using PizzaOrderAPI.Models;
namespace PizzaOrderAPI.Interfaces
{
    public interface ITokenServices
    {
        public string GenerateToken(User user);
    }
}
