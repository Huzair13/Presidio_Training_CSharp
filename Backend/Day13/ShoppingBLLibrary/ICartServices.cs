using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartServices
    {
        Task<Cart> CreateCart(int customerId);
        Task<Cart> AddCartItem(int cartId, int productId, int quantity);
        Task<Cart> RemoveCartItem(int cartId, int productId);
        Task<double> CalculateTotalAmountAfterDiscountAndShippingCharge(Cart cart);
        Task<Cart> GetCartByCustomerID(int CustomerId);
    }
}
