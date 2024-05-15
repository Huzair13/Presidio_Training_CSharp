using PizzaOrderAPI.Models;
using PizzaOrderAPI.Models.DTOs;

namespace PizzaOrderAPI.Interfaces
{
    public interface IUserLoginServices
    {
        public Task<User> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserDTO userDTO);
    }
}
