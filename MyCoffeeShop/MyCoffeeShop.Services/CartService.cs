using MyCoffeeShop.Core.Contracts;
using MyCoffeeShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeShop.Services
{
    public class CartService : ICartService
    {
        private IRepository<MenuItem> MenuItemRepository { get; set; }
        private IRepository<CartItem> CartItemRepository { get; set;}

        public CartService(IRepository<MenuItem> menuItemRepository, IRepository<CartItem> cartItemRepository)
        {
            MenuItemRepository = menuItemRepository;
            CartItemRepository = cartItemRepository;
        }
    }
}
