using MyCoffeeShop.Core.dto;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCoffeeShop.Core.Contracts
{
    public interface ICartService
    {
        Cart CreateCart();
        void AddToCart(string cartItemId);
        void RemoveFromCart(string cartItemId);
        Cart GetCart(bool createIfNull);
        List<CartItemDto> GetCartItems();
    }
}
