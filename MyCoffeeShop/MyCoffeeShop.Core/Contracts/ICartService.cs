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
        Cart CreateCart(HttpContextBase httpContext);
        void AddToCart(HttpContextBase httpContext, string cartItemId);
        void RemoveFromCart(HttpContextBase httpContext, string cartItemId);
        Cart GetCart(HttpContextBase httpContext, bool createIfNull);
        List<CartItemDto> GetCartItems(HttpContextBase httpContext);
    }
}
